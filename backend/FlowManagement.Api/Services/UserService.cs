using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using FlowManagement.Api.Data;
using FlowManagement.Api.DTOs.User;
using FlowManagement.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using BC = BCrypt.Net.BCrypt;

namespace FlowManagement.Api.Services
{
    /// <summary>
    /// 用户服务实现
    /// </summary>
    public class UserService : IUserService
    {
        private readonly FlowManagementDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILogger<UserService> _logger;

        public UserService(FlowManagementDbContext context, IMapper mapper, IConfiguration configuration, ILogger<UserService> logger)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            try
            {
                _logger.LogInformation($"开始注册用户: {registerDto.Username}");
                _logger.LogInformation($"请求数据: {System.Text.Json.JsonSerializer.Serialize(registerDto)}");

                // 检查用户名是否已存在
                _logger.LogInformation("检查用户名是否存在...");
                if (await IsUsernameExistsAsync(registerDto.Username))
                {
                    throw new InvalidOperationException("用户名已存在");
                }

                // 检查邮箱是否已存在
                _logger.LogInformation("检查邮箱是否存在...");
                if (await IsEmailExistsAsync(registerDto.Email))
                {
                    throw new InvalidOperationException("邮箱已被注册");
                }

                _logger.LogInformation("创建用户实体...");
                // 使用 AutoMapper 创建用户实体
                var user = _mapper.Map<User>(registerDto);
                // 手动设置密码哈希
                user.PasswordHash = BC.HashPassword(registerDto.Password);
                // 设置默认值
                user.CreatedTime = DateTime.Now;
                user.Role = "User";
                user.IsDeleted = false;

                _logger.LogInformation($"映射后的用户实体: {System.Text.Json.JsonSerializer.Serialize(user)}");

                _logger.LogInformation("保存到数据库...");
                try
                {
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    _logger.LogError(ex, "保存到数据库时出错");
                    if (ex.InnerException != null)
                    {
                        _logger.LogError($"内部错误: {ex.InnerException.Message}");
                        _logger.LogError($"堆栈跟踪: {ex.InnerException.StackTrace}");
                    }
                    throw;
                }

                _logger.LogInformation("映射到 DTO...");
                // 返回用户信息
                var userDto = _mapper.Map<UserDto>(user);
                _logger.LogInformation($"注册成功: {userDto.Username}");
                return userDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"注册失败: {ex.Message}");
                if (ex.InnerException != null)
                {
                    _logger.LogError($"内部错误: {ex.InnerException.Message}");
                    _logger.LogError($"堆栈跟踪: {ex.InnerException.StackTrace}");
                }
                throw;
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        public async Task<LoginResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == loginDto.Username);

            if (user == null || !BC.Verify(loginDto.Password, user.PasswordHash))
            {
                throw new InvalidOperationException("用户名或密码错误");
            }

            // 更新最后登录时间
            user.LastLoginTime = DateTime.Now;
            await _context.SaveChangesAsync();

            // 生成 JWT 令牌
            var token = GenerateJwtToken(_mapper.Map<UserDto>(user));

            return new LoginResponseDto
            {
                AccessToken = token,
                TokenType = "Bearer",
                ExpiresIn = 7200, // 令牌有效期2小时
                User = _mapper.Map<UserDto>(user)
            };
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new KeyNotFoundException("用户不存在");
            }

            return _mapper.Map<UserDto>(user);
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        public async Task<bool> IsUsernameExistsAsync(string username)
        {
            return await _context.Users
                .AnyAsync(u => u.Username == username);
        }

        /// <summary>
        /// 检查邮箱是否存在
        /// </summary>
        public async Task<bool> IsEmailExistsAsync(string email)
        {
            return await _context.Users
                .AnyAsync(u => u.Email == email);
        }

        /// <summary>
        /// 更新最后登录时间
        /// </summary>
        public async Task UpdateLastLoginTimeAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                user.LastLoginTime = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// 生成JWT令牌
        /// </summary>
        public string GenerateJwtToken(UserDto user)
        {
            var jwtKey = _configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT key is not configured");
            var jwtIssuer = _configuration["Jwt:Issuer"] ?? throw new InvalidOperationException("JWT issuer is not configured");
            var jwtAudience = _configuration["Jwt:Audience"] ?? throw new InvalidOperationException("JWT audience is not configured");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email ?? string.Empty)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

using FlowManagement.Api.DTOs.User;
using FlowManagement.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FlowManagement.Api.Controllers
{
    /// <summary>
    /// 用户管理控制器
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="registerDto">注册信息</param>
        /// <returns>注册成功的用户信息</returns>
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            try
            {
                _logger.LogInformation($"收到注册请求: {System.Text.Json.JsonSerializer.Serialize(registerDto)}");
                
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("模型验证失败");
                    return BadRequest(ModelState);
                }

                var result = await _userService.RegisterAsync(registerDto);
                _logger.LogInformation($"用户注册成功: {result.Username}");
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning($"注册业务错误: {ex.Message}");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "用户注册时发生错误");
                return StatusCode(500, new { message = "注册失败，请稍后重试", error = ex.Message });
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginDto">登录信息</param>
        /// <returns>登录响应信息，包含令牌和用户信息</returns>
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                _logger.LogInformation($"收到登录请求: {System.Text.Json.JsonSerializer.Serialize(loginDto)}");
                
                if (!ModelState.IsValid)
                {
                    _logger.LogWarning("模型验证失败");
                    return BadRequest(ModelState);
                }

                var response = await _userService.LoginAsync(loginDto);
                _logger.LogInformation($"用户登录成功: {loginDto.Username}");
                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning($"登录业务错误: {ex.Message}");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "用户登录时发生错误");
                return StatusCode(500, new { message = "登录失败，请稍后重试", error = ex.Message });
            }
        }

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns>用户信息</returns>
        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            try
            {
                var userIdClaim = User.FindFirst("sub") ?? throw new InvalidOperationException("用户ID不存在");
                var userId = int.Parse(userIdClaim.Value);
                var user = await _userService.GetUserByIdAsync(userId);
                _logger.LogInformation($"获取当前用户信息成功: {user.Username}");
                return Ok(user);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning($"获取当前用户信息业务错误: {ex.Message}");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "获取当前用户信息时发生错误");
                return StatusCode(500, new { message = "获取当前用户信息失败，请稍后重试", error = ex.Message });
            }
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>true表示存在，false表示不存在</returns>
        [HttpGet("check-username/{username}")]
        public async Task<ActionResult<bool>> CheckUsername(string username)
        {
            try
            {
                _logger.LogInformation($"收到检查用户名请求: {username}");
                
                var exists = await _userService.IsUsernameExistsAsync(username);
                _logger.LogInformation($"检查用户名结果: {exists}");
                return Ok(new { exists });
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning($"检查用户名业务错误: {ex.Message}");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "检查用户名时发生错误");
                return StatusCode(500, new { message = "检查用户名失败，请稍后重试", error = ex.Message });
            }
        }

        /// <summary>
        /// 检查邮箱是否存在
        /// </summary>
        /// <param name="email">电子邮箱</param>
        /// <returns>true表示存在，false表示不存在</returns>
        [HttpGet("check-email")]
        public async Task<ActionResult<bool>> CheckEmail([FromQuery] string email)
        {
            try
            {
                _logger.LogInformation($"收到检查邮箱请求: {email}");
                
                var exists = await _userService.IsEmailExistsAsync(email);
                _logger.LogInformation($"检查邮箱结果: {exists}");
                return Ok(new { exists });
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning($"检查邮箱业务错误: {ex.Message}");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "检查邮箱时发生错误");
                return StatusCode(500, new { message = "检查邮箱失败，请稍后重试", error = ex.Message });
            }
        }
    }
}

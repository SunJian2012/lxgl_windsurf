using FlowManagement.Api.DTOs.User;

namespace FlowManagement.Api.Services
{
    /// <summary>
    /// 用户服务接口
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="registerDto">注册信息</param>
        /// <returns>注册成功的用户信息</returns>
        Task<UserDto> RegisterAsync(RegisterDto registerDto);

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginDto">登录信息</param>
        /// <returns>登录响应信息，包含令牌和用户信息</returns>
        Task<LoginResponseDto> LoginAsync(LoginDto loginDto);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>用户信息</returns>
        Task<UserDto> GetUserByIdAsync(int userId);

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>true表示存在，false表示不存在</returns>
        Task<bool> IsUsernameExistsAsync(string username);

        /// <summary>
        /// 检查邮箱是否存在
        /// </summary>
        /// <param name="email">电子邮箱</param>
        /// <returns>true表示存在，false表示不存在</returns>
        Task<bool> IsEmailExistsAsync(string email);

        /// <summary>
        /// 更新最后登录时间
        /// </summary>
        /// <param name="userId">用户ID</param>
        Task UpdateLastLoginTimeAsync(int userId);

        /// <summary>
        /// 生成JWT令牌
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns>JWT令牌</returns>
        string GenerateJwtToken(UserDto user);
    }
}

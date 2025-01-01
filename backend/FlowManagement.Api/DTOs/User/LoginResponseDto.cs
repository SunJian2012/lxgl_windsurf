namespace FlowManagement.Api.DTOs.User
{
    /// <summary>
    /// 登录响应 DTO
    /// </summary>
    public class LoginResponseDto
    {
        /// <summary>
        /// 访问令牌
        /// </summary>
        public required string AccessToken { get; set; }

        /// <summary>
        /// 令牌类型
        /// </summary>
        public string TokenType { get; set; } = "Bearer";

        /// <summary>
        /// 过期时间（秒）
        /// </summary>
        public int ExpiresIn { get; set; } = 7200;

        /// <summary>
        /// 用户信息
        /// </summary>
        public required UserDto User { get; set; }
    }
}

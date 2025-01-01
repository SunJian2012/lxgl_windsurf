using System.ComponentModel.DataAnnotations;

namespace FlowManagement.Api.DTOs.User
{
    /// <summary>
    /// 用户登录 DTO
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public required string Username { get; set; }

        /// <summary>
    /// 密码
    /// </summary>
        [Required]
        public required string Password { get; set; }
    }
}

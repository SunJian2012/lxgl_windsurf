using System.ComponentModel.DataAnnotations;

namespace FlowManagement.Api.DTOs.User
{
    /// <summary>
    /// 用户注册 DTO
    /// </summary>
    public class RegisterDto
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

        /// <summary>
        /// 确认密码
        /// </summary>
        [Required]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配")]
        public required string ConfirmPassword { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        [Required]
        public required string PhoneNumber { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [Required]
        public required string RealName { get; set; }
    }
}

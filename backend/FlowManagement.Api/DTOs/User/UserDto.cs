namespace FlowManagement.Api.DTOs.User
{
    /// <summary>
    /// 用户信息DTO
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public required string Username { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public required string PhoneNumber { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public required string RealName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginAt { get; set; }

        /// <summary>
        /// 角色列表
        /// </summary>
        public required List<string> Roles { get; set; }
    }
}

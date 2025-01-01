using System;
using System.ComponentModel.DataAnnotations;

namespace FlowManagement.Api.Models
{
    /// <summary>
    /// 用户实体
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [MaxLength(50)]
        public required string Username { get; set; }

        /// <summary>
        /// 密码哈希
        /// </summary>
        [Required]
        [MaxLength(100)]
        public required string PasswordHash { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public required string Email { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Required]
        [MaxLength(20)]
        public required string Phone { get; set; }

        /// <summary>
        /// 角色（Admin、User等）
        /// </summary>
        [Required]
        [MaxLength(20)]
        public required string Role { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedTime { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}

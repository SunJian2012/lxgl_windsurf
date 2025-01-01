using System;
using System.ComponentModel.DataAnnotations;

namespace FlowManagement.Api.Models
{
    /// <summary>
    /// 企业信息实体
    /// </summary>
    public class Enterprise
    {
        /// <summary>
        /// 企业ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 企业编码
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Code { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// 企业类型（生产商、经销商等）
        /// </summary>
        [MaxLength(50)]
        public string? Type { get; set; }

        /// <summary>
        /// 许可证号
        /// </summary>
        [MaxLength(100)]
        public string? LicenseNumber { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [MaxLength(500)]
        public string? Address { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [MaxLength(50)]
        public string? Phone { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}

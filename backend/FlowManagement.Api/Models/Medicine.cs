using System;
using System.ComponentModel.DataAnnotations;

namespace FlowManagement.Api.Models
{
    /// <summary>
    /// 药品信息实体
    /// </summary>
    public class Medicine
    {
        /// <summary>
        /// 药品ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 药品编码
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Code { get; set; }

        /// <summary>
        /// 药品名称
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        [MaxLength(50)]
        public string? Specification { get; set; }

        /// <summary>
        /// 生产厂家
        /// </summary>
        [MaxLength(200)]
        public string? Manufacturer { get; set; }

        /// <summary>
        /// 批准文号
        /// </summary>
        [MaxLength(100)]
        public string? ApprovalNumber { get; set; }

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

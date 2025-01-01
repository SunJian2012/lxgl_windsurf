using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowManagement.Api.Models
{
    /// <summary>
    /// 流向记录实体
    /// </summary>
    public class FlowRecord
    {
        /// <summary>
        /// 记录ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 药品ID
        /// </summary>
        public int MedicineId { get; set; }

        /// <summary>
        /// 药品信息
        /// </summary>
        [ForeignKey("MedicineId")]
        public Medicine Medicine { get; set; }

        /// <summary>
        /// 来源企业ID
        /// </summary>
        public int SourceEnterpriseId { get; set; }

        /// <summary>
        /// 来源企业
        /// </summary>
        [ForeignKey("SourceEnterpriseId")]
        public Enterprise SourceEnterprise { get; set; }

        /// <summary>
        /// 目标企业ID
        /// </summary>
        public int TargetEnterpriseId { get; set; }

        /// <summary>
        /// 目标企业
        /// </summary>
        [ForeignKey("TargetEnterpriseId")]
        public Enterprise TargetEnterprise { get; set; }

        /// <summary>
        /// 交易类型（进货、销售等）
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string TransactionType { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Quantity { get; set; }

        /// <summary>
        /// 批号
        /// </summary>
        [MaxLength(50)]
        public string BatchNumber { get; set; }

        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime? ProductionDate { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// 交易日期
        /// </summary>
        public DateTime TransactionDate { get; set; }

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

namespace FlowManagement.Api.DTOs.Medicine
{
    /// <summary>
    /// 药品信息 DTO
    /// </summary>
    public class MedicineDto
    {
        /// <summary>
        /// 药品ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 药品编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 药品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string? Specification { get; set; }

        /// <summary>
        /// 生产厂家
        /// </summary>
        public string? Manufacturer { get; set; }

        /// <summary>
        /// 批准文号
        /// </summary>
        public string? ApprovalNumber { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdatedTime { get; set; }
    }
}

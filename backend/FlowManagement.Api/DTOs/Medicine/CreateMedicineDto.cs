using System.ComponentModel.DataAnnotations;

namespace FlowManagement.Api.DTOs.Medicine
{
    /// <summary>
    /// 创建药品请求 DTO
    /// </summary>
    public class CreateMedicineDto
    {
        /// <summary>
        /// 药品编码
        /// </summary>
        [Required(ErrorMessage = "药品编码不能为空")]
        [MaxLength(50, ErrorMessage = "药品编码最大长度为50")]
        public string Code { get; set; }

        /// <summary>
        /// 药品名称
        /// </summary>
        [Required(ErrorMessage = "药品名称不能为空")]
        [MaxLength(100, ErrorMessage = "药品名称最大长度为100")]
        public string Name { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        [MaxLength(50, ErrorMessage = "规格最大长度为50")]
        public string? Specification { get; set; }

        /// <summary>
        /// 生产厂家
        /// </summary>
        [MaxLength(200, ErrorMessage = "生产厂家最大长度为200")]
        public string? Manufacturer { get; set; }

        /// <summary>
        /// 批准文号
        /// </summary>
        [MaxLength(100, ErrorMessage = "批准文号最大长度为100")]
        public string? ApprovalNumber { get; set; }
    }
}

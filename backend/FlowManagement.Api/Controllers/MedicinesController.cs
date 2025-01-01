using FlowManagement.Api.DTOs.Medicine;
using FlowManagement.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlowManagement.Api.Controllers
{
    /// <summary>
    /// 药品信息控制器
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineService _medicineService;

        public MedicinesController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        /// <summary>
        /// 获取药品列表
        /// </summary>
        /// <param name="keyword">搜索关键词（药品编码、名称）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <returns>药品列表</returns>
        [HttpGet]
        public async Task<IActionResult> GetMedicines(
            [FromQuery] string keyword = "",
            [FromQuery] int pageIndex = 1,
            [FromQuery] int pageSize = 10)
        {
            var (items, totalCount) = await _medicineService.GetMedicinesAsync(keyword, pageIndex, pageSize);
            return Ok(new { items, totalCount });
        }

        /// <summary>
        /// 获取药品详情
        /// </summary>
        /// <param name="id">药品ID</param>
        /// <returns>药品详情</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicine(int id)
        {
            var medicine = await _medicineService.GetMedicineByIdAsync(id);
            return Ok(medicine);
        }

        /// <summary>
        /// 创建药品
        /// </summary>
        /// <param name="dto">创建药品请求</param>
        /// <returns>创建的药品信息</returns>
        [HttpPost]
        public async Task<IActionResult> CreateMedicine([FromBody] CreateMedicineDto dto)
        {
            var medicine = await _medicineService.CreateMedicineAsync(dto);
            return CreatedAtAction(nameof(GetMedicine), new { id = medicine.Id }, medicine);
        }

        /// <summary>
        /// 更新药品
        /// </summary>
        /// <param name="id">药品ID</param>
        /// <param name="dto">更新药品请求</param>
        /// <returns>更新后的药品信息</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedicine(int id, [FromBody] UpdateMedicineDto dto)
        {
            var medicine = await _medicineService.UpdateMedicineAsync(id, dto);
            return Ok(medicine);
        }

        /// <summary>
        /// 删除药品
        /// </summary>
        /// <param name="id">药品ID</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            await _medicineService.DeleteMedicineAsync(id);
            return NoContent();
        }

        /// <summary>
        /// 检查药品编码是否存在
        /// </summary>
        /// <param name="code">药品编码</param>
        /// <returns>是否存在</returns>
        [HttpGet("check-code/{code}")]
        public async Task<IActionResult> CheckMedicineCode(string code)
        {
            var exists = await _medicineService.IsMedicineCodeExistsAsync(code);
            return Ok(new { exists });
        }
    }
}

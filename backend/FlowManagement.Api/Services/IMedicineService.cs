using FlowManagement.Api.DTOs.Medicine;

namespace FlowManagement.Api.Services
{
    /// <summary>
    /// 药品服务接口
    /// </summary>
    public interface IMedicineService
    {
        /// <summary>
        /// 获取药品列表
        /// </summary>
        /// <param name="keyword">搜索关键词（药品编码、名称）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <returns>药品列表</returns>
        Task<(List<MedicineDto> Items, int TotalCount)> GetMedicinesAsync(string keyword, int pageIndex, int pageSize);

        /// <summary>
        /// 获取药品详情
        /// </summary>
        /// <param name="id">药品ID</param>
        /// <returns>药品详情</returns>
        Task<MedicineDto> GetMedicineByIdAsync(int id);

        /// <summary>
        /// 创建药品
        /// </summary>
        /// <param name="dto">创建药品请求</param>
        /// <returns>创建的药品信息</returns>
        Task<MedicineDto> CreateMedicineAsync(CreateMedicineDto dto);

        /// <summary>
        /// 更新药品
        /// </summary>
        /// <param name="id">药品ID</param>
        /// <param name="dto">更新药品请求</param>
        /// <returns>更新后的药品信息</returns>
        Task<MedicineDto> UpdateMedicineAsync(int id, UpdateMedicineDto dto);

        /// <summary>
        /// 删除药品
        /// </summary>
        /// <param name="id">药品ID</param>
        Task DeleteMedicineAsync(int id);

        /// <summary>
        /// 检查药品编码是否存在
        /// </summary>
        /// <param name="code">药品编码</param>
        /// <returns>是否存在</returns>
        Task<bool> IsMedicineCodeExistsAsync(string code);
    }
}

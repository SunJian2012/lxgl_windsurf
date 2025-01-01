using AutoMapper;
using FlowManagement.Api.Data;
using FlowManagement.Api.DTOs.Medicine;
using FlowManagement.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowManagement.Api.Services
{
    /// <summary>
    /// 药品服务实现
    /// </summary>
    public class MedicineService : IMedicineService
    {
        private readonly FlowManagementDbContext _context;
        private readonly IMapper _mapper;

        public MedicineService(FlowManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<(List<MedicineDto> Items, int TotalCount)> GetMedicinesAsync(string keyword, int pageIndex, int pageSize)
        {
            var query = _context.Medicines.AsQueryable();

            // 关键词搜索
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                query = query.Where(m => m.Code.Contains(keyword) || m.Name.Contains(keyword));
            }

            // 获取总数
            var totalCount = await query.CountAsync();

            // 分页查询
            var items = await query
                .OrderByDescending(m => m.CreatedTime)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (_mapper.Map<List<MedicineDto>>(items), totalCount);
        }

        /// <inheritdoc/>
        public async Task<MedicineDto> GetMedicineByIdAsync(int id)
        {
            var medicine = await _context.Medicines.FindAsync(id);
            if (medicine == null || medicine.IsDeleted)
            {
                throw new KeyNotFoundException($"未找到ID为{id}的药品信息");
            }

            return _mapper.Map<MedicineDto>(medicine);
        }

        /// <inheritdoc/>
        public async Task<MedicineDto> CreateMedicineAsync(CreateMedicineDto dto)
        {
            // 检查药品编码是否已存在
            if (await IsMedicineCodeExistsAsync(dto.Code))
            {
                throw new InvalidOperationException($"药品编码{dto.Code}已存在");
            }

            var medicine = _mapper.Map<Medicine>(dto);
            medicine.CreatedTime = DateTime.Now;

            _context.Medicines.Add(medicine);
            await _context.SaveChangesAsync();

            return _mapper.Map<MedicineDto>(medicine);
        }

        /// <inheritdoc/>
        public async Task<MedicineDto> UpdateMedicineAsync(int id, UpdateMedicineDto dto)
        {
            var medicine = await _context.Medicines.FindAsync(id);
            if (medicine == null || medicine.IsDeleted)
            {
                throw new KeyNotFoundException($"未找到ID为{id}的药品信息");
            }

            _mapper.Map(dto, medicine);
            medicine.UpdatedTime = DateTime.Now;

            await _context.SaveChangesAsync();

            return _mapper.Map<MedicineDto>(medicine);
        }

        /// <inheritdoc/>
        public async Task DeleteMedicineAsync(int id)
        {
            var medicine = await _context.Medicines.FindAsync(id);
            if (medicine == null || medicine.IsDeleted)
            {
                throw new KeyNotFoundException($"未找到ID为{id}的药品信息");
            }

            // 检查是否有关联的流向记录
            var hasFlowRecords = await _context.FlowRecords.AnyAsync(f => f.MedicineId == id && !f.IsDeleted);
            if (hasFlowRecords)
            {
                throw new InvalidOperationException("该药品已有流向记录，无法删除");
            }

            medicine.IsDeleted = true;
            medicine.UpdatedTime = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<bool> IsMedicineCodeExistsAsync(string code)
        {
            return await _context.Medicines.AnyAsync(m => m.Code == code && !m.IsDeleted);
        }
    }
}

using AutoMapper;
using FlowManagement.Api.DTOs.Medicine;
using FlowManagement.Api.Models;

namespace FlowManagement.Api.Configurations
{
    /// <summary>
    /// AutoMapper 配置文件
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // 药品信息映射配置
            CreateMap<Medicine, MedicineDto>();
            CreateMap<CreateMedicineDto, Medicine>();
            CreateMap<UpdateMedicineDto, Medicine>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}

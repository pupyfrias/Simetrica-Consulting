using AutoMapper;
using SimetricaConsulting.Application.Models.Dtos.V1.Dashboard;
using SimetricaConsulting.Domain.Entities.V1;

namespace SimetricaConsulting.Application.Mappings.V1
{
    public class DashboardProfile : Profile
    {
        public DashboardProfile()
        {
            CreateMap<Dashboard, DashboardListDto>();
            CreateMap<Dashboard, DashboardExportDto>();
            CreateMap<DashboardCreateDto, Dashboard>();
            CreateMap<DashboardUpdateDto, Dashboard>();
            CreateMap<Dashboard, DashboardDetailDto>();
        }
    }
}
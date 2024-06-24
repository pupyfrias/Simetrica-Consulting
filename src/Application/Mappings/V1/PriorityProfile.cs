using AutoMapper;
using SimetricaConsulting.Application.Models.Dtos.V1.Priority;
using SimetricaConsulting.Domain.Entities.V1;

namespace SimetricaConsulting.Application.Mappings.V1
{
    public class PriorityProfile : Profile
    {
        public PriorityProfile()
        {
            CreateMap<Priority, PriorityListDto>();
            CreateMap<Priority, PriorityExportDto>();
            CreateMap<PriorityCreateDto, Priority>();
            CreateMap<PriorityUpdateDto, Priority>();
            CreateMap<Priority, PriorityDetailDto>();
        }
    }
}
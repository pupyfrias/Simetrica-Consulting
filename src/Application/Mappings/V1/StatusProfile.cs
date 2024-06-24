using AutoMapper;
using SimetricaConsulting.Application.Models.Dtos.V1.Status;
using SimetricaConsulting.Domain.Entities.V1;

namespace SimetricaConsulting.Application.Mappings.V1
{
    public class StatusProfile : Profile
    {
        public StatusProfile()
        {
            CreateMap<Status, StatusListDto>();
            CreateMap<Status, StatusExportDto>();
            CreateMap<StatusCreateDto, Status>();
            CreateMap<StatusUpdateDto, Status>();
            CreateMap<Status, StatusDetailDto>();
        }
    }
}
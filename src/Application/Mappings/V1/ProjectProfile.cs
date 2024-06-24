using AutoMapper;
using SimetricaConsulting.Application.Models.Dtos.V1.Project;
using SimetricaConsulting.Domain.Entities.V1;

namespace SimetricaConsulting.Application.Mappings.V1
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectListDto>();
            CreateMap<Project, ProjectExportDto>();
            CreateMap<ProjectCreateDto, Project>();
            CreateMap<ProjectUpdateDto, Project>();
            CreateMap<Project, ProjectDetailDto>();
        }
    }
}
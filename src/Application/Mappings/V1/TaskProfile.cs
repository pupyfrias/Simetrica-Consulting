using AutoMapper;
using SimetricaConsulting.Application.Models.Dtos.V1.Task;
using SimetricaConsulting.Domain.Entities.V1;
using Task = SimetricaConsulting.Domain.Entities.V1.Task;

namespace SimetricaConsulting.Application.Mappings.V1
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Task, TaskListDto>();
            CreateMap<Task, TaskExportDto>();
            CreateMap<TaskCreateDto, Task>();
            CreateMap<TaskUpdateDto, Task>();
            CreateMap<Task, TaskDetailDto>();
        }
    }
}
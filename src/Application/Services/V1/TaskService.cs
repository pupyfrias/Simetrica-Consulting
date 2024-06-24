using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using SimetricaConsulting.Application.Contracts.Repositories.V1;
using SimetricaConsulting.Application.Contracts.Services.V1;
using Task = SimetricaConsulting.Domain.Entities.V1.Task;

namespace SimetricaConsulting.Application.Services.V1
{
    public class TaskService : ServiceBase<Task>, ITaskService
    {
        public TaskService(ITaskRepository repository, IMapper mapper, IHttpContextAccessor httpContext, IMemoryCache cache) : base(repository, mapper, httpContext, cache)
        {
           
        }
    }
}
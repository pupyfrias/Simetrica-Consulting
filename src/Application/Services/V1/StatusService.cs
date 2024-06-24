using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using SimetricaConsulting.Application.Contracts.Repositories.V1;
using SimetricaConsulting.Application.Contracts.Services.V1;
using SimetricaConsulting.Domain.Entities.V1;

namespace SimetricaConsulting.Application.Services.V1
{
    public class StatusService : ServiceBase<Status>, IStatusService
    {
        public StatusService(IStatusRepository repository, IMapper mapper, IHttpContextAccessor httpContext, IMemoryCache cache) : base(repository, mapper, httpContext, cache)
        {
        }
    }
}
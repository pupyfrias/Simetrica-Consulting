using AutoMapper;
using SimetricaConsulting.Application.Contracts.Repositories.V1;
using SimetricaConsulting.Domain.Entities.V1;
using SimetricaConsulting.Persistence.DbContexts.V1;

namespace SimetricaConsulting.Persistence.Repositories.V1
{
    public class StatusRepository : RepositoryBase<Status>, IStatusRepository
    {
        public StatusRepository(ApplicationDbContext context, IConfigurationProvider configurationProvider) : base(context, configurationProvider)
        {
        }
    }
}
using AutoMapper;
using SimetricaConsulting.Application.Contracts.Repositories.V1;
using SimetricaConsulting.Domain.Entities.V1;
using SimetricaConsulting.Persistence.DbContexts.V1;


namespace SimetricaConsulting.Persistence.Repositories.V1
{
    public class DashboardRepository : RepositoryBase<Dashboard>, IDashboardRepository
    {
        public DashboardRepository(ApplicationDbContext context, IConfigurationProvider configurationProvider) : base(context, configurationProvider)
        {
        }
    }
}
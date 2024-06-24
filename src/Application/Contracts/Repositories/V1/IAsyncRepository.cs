using System.Linq.Expressions;

namespace SimetricaConsulting.Application.Contracts.Repositories.V1
{
    public interface IAsyncRepository<TEntity>
    {
        Task<TEntity> CreateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task<List<TDestination>> GetAllProjectedWithPaginationAsync<TDestination>(ISpecification<TEntity> spec);

        Task<List<TDestination>> GetAllProjectedAsync<TDestination>();

        Task<TEntity?> GetByIdAsync<TKey>(TKey id);

        Task<TDestination?> GetByIdProjectedAsync<TKey, TDestination>(TKey id);

        Task<int> GetTotalCountAsync(Expression<Func<TEntity, bool>>? criteria);

        Task UpdateAsync(TEntity entity);

        Task<IList<TDestination>> GetAllProjecteDtoExportAsync<TDestination>(ISpecification<TEntity> spec);
    }
}
using SimetricaConsulting.Domain.Entities.V1;
using Task = SimetricaConsulting.Domain.Entities.V1.Task;

namespace SimetricaConsulting.Application.Contracts.Repositories.V1
{
    public interface ITaskRepository : IAsyncRepository<Task>
    {
    }
}
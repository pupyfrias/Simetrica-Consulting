using SimetricaConsulting.Domain.Entities.V1;
using Task = SimetricaConsulting.Domain.Entities.V1.Task;

namespace SimetricaConsulting.Application.Contracts.Services.V1
{
    public interface ITaskService : IAsyncService<Task>
    {
    }
}
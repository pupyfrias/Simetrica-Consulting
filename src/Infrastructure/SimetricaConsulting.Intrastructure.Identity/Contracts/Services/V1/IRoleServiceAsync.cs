using SimetricaConsulting.Application.Models.Dtos.V1.Role;
using SimetricaConsulting.Application.Models.Wrappers;

namespace SimetricaConsulting.Identity.Contracts.Services.V1
{
    public interface IRoleServiceAsync
    {
        Task<ApiResponse<List<RoleListDto>>> GetAllAsync();
    }
}
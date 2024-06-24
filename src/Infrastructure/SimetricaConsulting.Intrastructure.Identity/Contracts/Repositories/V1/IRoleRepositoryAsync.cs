using SimetricaConsulting.Application.Models.Dtos.V1.Role;
using System.Security.Claims;

namespace SimetricaConsulting.Identity.Contracts.Repositories.V1
{
    public interface IRoleRepositoryAsync
    {
        Task<List<RoleListDto>> GetAllAsync();

        Task<List<Claim>> GetClaims(string roleName);
    }
}
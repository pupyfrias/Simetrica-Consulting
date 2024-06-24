using Microsoft.AspNetCore.Identity;
using SimetricaConsulting.Application.Models.Dtos.V1.User;
using SimetricaConsulting.Identity.Entities;
using SimetricaConsulting.Identity.Specification.V1;
using System.Linq.Expressions;

namespace SimetricaConsulting.Identity.Contracts.Repositories.V1
{
    public interface IUserRepositoryAsync
    {
        Task AdDtoRoleAsync(IdentityUserRole<string> userRoles);

        Task AdDtoRolesAsync(List<IdentityUserRole<string>> identityUserRoles);

        Task<List<UserListDto>> GetAllProjectedWithPaginationAsync(UserSpecification spec);

        Task<int> GetTotalRecordsAsync(Expression<Func<User, bool>>? criteria);

        Task RemoveFromRoleAsync(IdentityUserRole<string> userRoles);

        Task RemoveFromRolesAsync(List<IdentityUserRole<string>> identityUserRoles);
    }
}
using SimetricaConsulting.Application.Models.Dtos.V1.User;
using SimetricaConsulting.Application.Models.Wrappers;
using SimetricaConsulting.Identity.Specification.V1;

namespace SimetricaConsulting.Identity.Contracts.Services.V1
{
    public interface IUserServiceAsync
    {


        Task AdDtoRolesAsync(Guid userId, List<Guid> roles);

        Task AdDtoRolesAsync(Guid userId, Guid roleId);

        Task DeleteAsync(Guid userId);

        Task<ApiResponse<PagedCollection<UserListDto>>> GetAllAsync(UserFilterRequest request);

        Task<ApiResponse<UserDetailDto>> GetByIdAsync(Guid userId);

        Task<ApiResponse<List<string>>> GetRolesAsync(Guid userId);

        Task RemoveFromRolesAsync(Guid userId, List<Guid> roles);

        Task RemoveFromRolesAsync(Guid userId, Guid roles);


        Task UpdateAsync(Guid userId, UserUpdateDto userUpdateDto);
    }
}
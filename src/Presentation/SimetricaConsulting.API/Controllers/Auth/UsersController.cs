using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimetricaConsulting.Application.Constants;
using SimetricaConsulting.Application.Models.Dtos.V1.Role;
using SimetricaConsulting.Application.Models.Dtos.V1.User;
using SimetricaConsulting.Application.Models.Wrappers;
using SimetricaConsulting.Identity.Contracts.Services.V1;
using SimetricaConsulting.Identity.Specification.V1;

namespace SimetricaConsulting.Api.Controllers.Auth
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UsersController : ControllerBase
    {
        #region Private Variable

        private readonly IUserServiceAsync _userServiceAsync;

        #endregion Private Variable

        public UsersController(IUserServiceAsync userService)
        {
            _userServiceAsync = userService;
        }

        #region Actions


        [Authorize(Roles = Roles.Admin)]
        [HttpPost("{id}/roles/{roleId}")]
        public async Task<ActionResult> AdDtoRoleAsync(Guid id, Guid roleId)
        {
            await _userServiceAsync.AdDtoRolesAsync(id, roleId);
            return NoContent();
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost("{id}/roles")]
        public async Task<ActionResult> AdDtoRolesAsync(Guid id, [FromBody] RoleIdsDto roleIdsDto)
        {
            await _userServiceAsync.AdDtoRolesAsync(id, roleIdsDto.RoleIds);
            return NoContent();
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _userServiceAsync.DeleteAsync(id);
            return NoContent();
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedCollection<UserListDto>>>> GetAllUsers([FromQuery] UserFilterRequest request)
        {
            var pagedUsersResult = await _userServiceAsync.GetAllAsync(request);
            return Ok(pagedUsersResult);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<UserDetailDto>>> GetByIdAsync(Guid id)
        {
            var user = await _userServiceAsync.GetByIdAsync(id);
            return Ok(user);
        }



        [Authorize(Roles = Roles.Admin)]
        [HttpGet("{id}/roles")]
        public async Task<ActionResult<ApiResponse<List<string>>>> GetRolesAsync(Guid id)
        {
            var response = await _userServiceAsync.GetRolesAsync(id);
            return Ok(response);
        }


        [Authorize(Roles = Roles.Admin)]
        [HttpDelete("{id}/roles/{roleId}")]
        public async Task<ActionResult> RemoveRoleAsync(Guid id, Guid roleId)
        {
            await _userServiceAsync.RemoveFromRolesAsync(id, roleId);
            return NoContent();
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpDelete("{id}/roles")]
        public async Task<ActionResult> RemoveRolesAsync(Guid id, [FromBody] RoleIdsDto roleIdsDto)
        {
            await _userServiceAsync.RemoveFromRolesAsync(id, roleIdsDto.RoleIds);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] UserUpdateDto userUpdateDto)
        {
            await _userServiceAsync.UpdateAsync(id, userUpdateDto);
            return NoContent();
        }

        #endregion Actions
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimetricaConsulting.Application.Constants;
using SimetricaConsulting.Application.Models.Dtos.V1.Role;
using SimetricaConsulting.Application.Models.Wrappers;
using SimetricaConsulting.Identity.Contracts.Services.V1;

namespace SimetricaConsulting.Api.Controllers.Auth
{
    [Authorize(Roles = Roles.Admin)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleServiceAsync _roleService;

        public RolesController(IRoleServiceAsync roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<RoleListDto>>>> GetAllAsync()
        {
            var response = await _roleService.GetAllAsync();
            return Ok(response);
        }
    }
}
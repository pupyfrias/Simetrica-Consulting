using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimetricaConsulting.Application.Models.Dtos.V1.Role;
using SimetricaConsulting.Identity.Contracts.Repositories.V1;
using System.Security.Claims;

namespace SimetricaConsulting.Identity.Repositories.V1
{
    public class RoleRepositoryAsync : IRoleRepositoryAsync
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public RoleRepositoryAsync(RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<List<RoleListDto>> GetAllAsync()
        {
            return await _roleManager.Roles
                .ProjectTo<RoleListDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<Claim>> GetClaims(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);

            return (List<Claim>)await _roleManager.GetClaimsAsync(role);
        }
    }
}
using Microsoft.Extensions.Caching.Memory;
using SimetricaConsulting.Application.Models.Dtos.V1.Role;
using SimetricaConsulting.Application.Models.Wrappers;
using SimetricaConsulting.Identity.Contracts.Repositories.V1;
using SimetricaConsulting.Identity.Contracts.Services.V1;

namespace SimetricaConsulting.Identity.Services.V1
{
    public class RoleServiceAsync : IRoleServiceAsync
    {
        private readonly IRoleRepositoryAsync _roleRepositoryAsync;
        private readonly IMemoryCache _cache;

        public RoleServiceAsync(IRoleRepositoryAsync roleRepositoryAsync, IMemoryCache cache)
        {
            _roleRepositoryAsync = roleRepositoryAsync;
            _cache = cache;
        }

        public async Task<ApiResponse<List<RoleListDto>>> GetAllAsync()
        {
            string cacheKey = $"RolesCache";

            if (!_cache.TryGetValue(cacheKey, out List<RoleListDto> roles))
            {
                roles = await _roleRepositoryAsync.GetAllAsync();
                _cache.Set(cacheKey, roles);
            }

            return new ApiResponse<List<RoleListDto>>(roles);
        }
    }
}
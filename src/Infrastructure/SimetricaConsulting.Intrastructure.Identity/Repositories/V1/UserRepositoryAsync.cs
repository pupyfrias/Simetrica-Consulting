using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimetricaConsulting.Application.Models.Dtos.V1.User;
using SimetricaConsulting.Identity.Contracts.Repositories.V1;
using SimetricaConsulting.Identity.DbContext.V1;
using SimetricaConsulting.Identity.Entities;
using SimetricaConsulting.Identity.Specification.V1;
using System.Linq.Expressions;

namespace SimetricaConsulting.Identity.Repositories.V1
{
    public class UserRepositoryAsync : IUserRepositoryAsync
    {
        private readonly IdentityContext _dbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserRepositoryAsync(UserManager<User> userManager, IMapper mapper, IdentityContext dbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public Task AdDtoRoleAsync(IdentityUserRole<string> userRoles)
        {
            _dbContext.UserRoles.Add(userRoles);
            return _dbContext.SaveChangesAsync();
        }

        public async Task AdDtoRolesAsync(List<IdentityUserRole<string>> identityUserRoles)
        {
            await _dbContext.UserRoles.AddRangeAsync(identityUserRoles);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<UserListDto>> GetAllProjectedWithPaginationAsync(UserSpecification spec)
        {
            var query = _userManager.Users.AsQueryable();

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if (spec.Descending)
            {
                query = query.OrderByDescending(spec.SortBy);
            }
            else
            {
                query = query.OrderBy(spec.SortBy);
            }

            return await query.Skip(spec.Skip)
                              .Take(spec.Take)
                              .ProjectTo<UserListDto>(_mapper.ConfigurationProvider)
                              .ToListAsync();
        }

        public async Task<int> GetTotalRecordsAsync(Expression<Func<User, bool>>? criteria)
        {
            if (criteria == null)
            {
                return await _dbContext.Users.CountAsync();
            }
            else
            {
                return await _dbContext.Users.Where(criteria).CountAsync();
            }
        }

        public async Task RemoveFromRoleAsync(IdentityUserRole<string> userRole)
        {
            _dbContext.UserRoles.Remove(userRole);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveFromRolesAsync(List<IdentityUserRole<string>> identityUserRoles)
        {
            _dbContext.UserRoles.RemoveRange(identityUserRoles);
            await _dbContext.SaveChangesAsync();
        }
    }
}
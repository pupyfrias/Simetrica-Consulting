using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using SimetricaConsulting.Application.Contracts.Services.V1;
using SimetricaConsulting.Application.Exceptions;
using SimetricaConsulting.Application.Extensions;
using SimetricaConsulting.Application.Models.Dtos.V1.User;
using SimetricaConsulting.Application.Models.Wrappers;
using SimetricaConsulting.Application.Utilities;
using SimetricaConsulting.Identity.Contracts.Repositories.V1;
using SimetricaConsulting.Identity.Contracts.Services.V1;
using SimetricaConsulting.Identity.Entities;
using SimetricaConsulting.Identity.Specification.V1;
using System.Data;

namespace SimetricaConsulting.Identity.Services.V1
{
    public class UserServiceAsync : IUserServiceAsync
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly IUserRepositoryAsync _userRepository;
        private readonly UserManager<User> _userManager;

        public UserServiceAsync(
            IUserRepositoryAsync userRepository,
            IMapper mapper,
            IEmailServiceAsync emailService,
            IHttpContextAccessor httpContext,
            UserManager<User> userManager
            )
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

      
        public async Task AdDtoRolesAsync(Guid userId, List<Guid> roles)
        {
            var user = await GetUser(userId);

            var userRoles = roles.Select(role => new IdentityUserRole<string>
            {
                UserId = user.Id,
                RoleId = role.ToString()
            }).ToList();

            await _userRepository.AdDtoRolesAsync(userRoles);
        }

        public async Task AdDtoRolesAsync(Guid userId, Guid roleId)
        {
            var user = await GetUser(userId);
            var userRole = new IdentityUserRole<string> { UserId = user.Id, RoleId = roleId.ToString() };
            await _userRepository.AdDtoRoleAsync(userRole);
        }

        public async Task DeleteAsync(Guid userId)
        {
            var user = await GetUser(userId);
            user.Active = false;
            await _userManager.UpdateAsync(user);
        }

        public async Task<ApiResponse<PagedCollection<UserListDto>>> GetAllAsync(UserFilterRequest request)
        {
            var spec = new UserSpecification(request);

            if (spec.Skip % spec.Take != 0)
            {
                throw new BadRequestException($"The 'offset' value ({spec.Skip}) must be either zero or a multiple of the 'limit' value({spec.Take}).");
            }

            var total = await _userRepository.GetTotalRecordsAsync(spec.Criteria);

            if (total < spec.Skip)
            {
                throw new BadRequestException($"The 'offset' value must be either zero or minimum to 'total' value ({total}) and multiple of the 'limit' value({spec.Take}).");
            }

            var userList = await _userRepository.GetAllProjectedWithPaginationAsync(spec);

            var href = _httpContext?.HttpContext?.Request.GetEncodedUrl();
            var next = UrlUtile.GetNextURL(href, request.Limit, request.Offset, total);
            var prev = UrlUtile.GetPrevURL(href, request.Limit, request.Offset);

            var data = new PagedCollection<UserListDto>
            {
                Elements = userList,
                HRef = href,
                Prev = prev,
                Next = next,
                Offset = request.Offset,
                Limit = request.Limit,
                Total = total
            };

            return new ApiResponse<PagedCollection<UserListDto>>(data);
        }

        public async Task<ApiResponse<UserDetailDto>> GetByIdAsync(Guid userId)
        {
            var user = await GetUser(userId);
            var roles = (List<string>)await _userManager.GetRolesAsync(user);
            var userDto = _mapper.Map<UserDetailDto>(user);
            userDto.Roles = roles;
            return new ApiResponse<UserDetailDto>(userDto);
        }

      
        public async Task<ApiResponse<List<string>>> GetRolesAsync(Guid userId)
        {
            var user = await GetUser(userId);
            var roles = (List<string>)await _userManager.GetRolesAsync(user);
            return new ApiResponse<List<string>>(roles);
        }

        public async Task RemoveFromRolesAsync(Guid userId, List<Guid> roles)
        {
            var user = await GetUser(userId);
            var userRoles = roles.Select(role => new IdentityUserRole<string>
            {
                UserId = user.Id,
                RoleId = role.ToString()
            }).ToList();

            await _userRepository.RemoveFromRolesAsync(userRoles);
        }

        public async Task RemoveFromRolesAsync(Guid userId, Guid roleId)
        {
            var user = await GetUser(userId);
            var userRole = new IdentityUserRole<string> { UserId = user.Id, RoleId = roleId.ToString() };
            await _userRepository.RemoveFromRoleAsync(userRole);
        }


        public async Task UpdateAsync(Guid userId, UserUpdateDto userUpdateDto)
        {
            var currentUserId = _httpContext?.HttpContext?.GetUserId();

            if (userId != userUpdateDto.Id)
            {
                throw new BadRequestException("The provided user ID does not match the ID in the request data.");
            }

            if (currentUserId != userUpdateDto.Id)
            {
                throw new ForbiddenException();
            }

            var user = await GetUser(userId);

            if (userUpdateDto.CurrentPassword != null && userUpdateDto.NewPassword != null && userUpdateDto.ConfirmPassword != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, userUpdateDto.CurrentPassword, userUpdateDto.NewPassword);

                if (!result.Succeeded)
                {
                    var errorMessage = string.Join("; ", result.Errors.Select(e => e.Description));
                    throw new BadRequestException($"User change password failed: {errorMessage}");
                }
            }

            _mapper.Map(userUpdateDto, user);
            await _userManager.UpdateAsync(user);
        }

        #region Private Methods

        private async Task<User> GetUser(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                throw new NotFoundException("User", userId);
            }

            return user;
        }

        #endregion Private Methods
    }
}
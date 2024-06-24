using SimetricaConsulting.Application.Models.Dtos.V1.Auth;
using SimetricaConsulting.Application.Models.Dtos.V1.User;
using SimetricaConsulting.Application.Models.Wrappers;

namespace SimetricaConsulting.Identity.Contracts.Services.V1
{
    public interface IAuthServiceAsync
    {
        Task<ApiResponse<AuthenticationResponseDto>> LoginAsync(LoginDto loginDto);

        Task<ApiResponse> ConfirmEmailAsync(ConfirmEmailDto confirmEmailDto);

        Task ForgotPassword(ForgotPasswordDto model);

        Task<ApiResponse> ResetPassword(ResetPasswordDto model);

        Task<ApiResponse> CreateAsync(UserCreateDto userCreateDto);

        Task<ApiResponse> ResendConfirmationEmailAsync(ResendConfirmationEmailDto resendConfirmationEmailDto);
    }
}
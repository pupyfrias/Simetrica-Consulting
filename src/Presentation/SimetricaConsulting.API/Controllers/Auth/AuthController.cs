using Microsoft.AspNetCore.Mvc;
using SimetricaConsulting.Application.Models.Dtos.V1.Auth;
using SimetricaConsulting.Application.Models.Dtos.V1.User;
using SimetricaConsulting.Application.Models.Wrappers;
using SimetricaConsulting.Identity.Contracts.Services.V1;

namespace SimetricaConsulting.Api.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServiceAsync _authService;

        public AuthController(IAuthServiceAsync authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<AuthenticationResponseDto>>> Login(LoginDto loginDto)
        {
            var response = await _authService.LoginAsync(loginDto);
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse>> RegisterAsync([FromBody] UserCreateDto userCreateDto)
        {
            var user = await _authService.CreateAsync(userCreateDto);
            return Ok(user);
        }

        [HttpPost("confirm-email")]
        public async Task<ActionResult<ApiResponse>> ConfirmEmailAsync([FromBody] ConfirmEmailDto confirmEmailDto)
        {
            var confirmaEmail = await _authService.ConfirmEmailAsync(confirmEmailDto);
            return Ok(confirmaEmail);
        }

        [HttpPost("resend-confirmation-email")]
        public async Task<IActionResult> ResendConfirmationEmail([FromBody] ResendConfirmationEmailDto resendConfirmationEmail)
        {
            var confirmaEmail = await _authService.ResendConfirmationEmailAsync(resendConfirmationEmail);
            return Ok(confirmaEmail);
        }

        [HttpPost("forgot-password")]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            await _authService.ForgotPassword(forgotPasswordDto);
            return NoContent();
        }

        [HttpPost("reset-password")]
        public async Task<ActionResult<ApiResponse>> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var resetPassword = await _authService.ResetPassword(resetPasswordDto);
            return Ok(resetPassword);
        }

    }
}
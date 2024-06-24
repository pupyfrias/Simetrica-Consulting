using SimetricaConsulting.Application.Models.Dtos.V1.Email;

namespace SimetricaConsulting.Application.Contracts.Services.V1
{
    public interface IEmailServiceAsync
    {
        Task SendEmailAsync(EmailDto emailDto);
    }
}
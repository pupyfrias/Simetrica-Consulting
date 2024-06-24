using System.ComponentModel.DataAnnotations;

namespace SimetricaConsulting.Application.Models.Dtos.V1.Auth
{
    public class ResendConfirmationEmailDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
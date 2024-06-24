using System.ComponentModel.DataAnnotations;

namespace SimetricaConsulting.Application.Models.Dtos.V1.Status
{
    public class StatusCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace SimetricaConsulting.Application.Models.Dtos.V1.Priority
{
    public class PriorityCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
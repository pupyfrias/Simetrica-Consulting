using System.ComponentModel.DataAnnotations;

namespace SimetricaConsulting.Application.Models.Dtos.V1.Status
{
    public class StatusUpdateDto
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
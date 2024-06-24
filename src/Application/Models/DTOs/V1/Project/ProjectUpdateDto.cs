using System.ComponentModel.DataAnnotations;

namespace SimetricaConsulting.Application.Models.Dtos.V1.Project
{
    public class ProjectUpdateDto
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
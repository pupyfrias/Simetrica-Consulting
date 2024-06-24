using System.ComponentModel.DataAnnotations;

namespace SimetricaConsulting.Application.Models.Dtos.V1.Task
{
    public class TaskCreateDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public int PriorityId { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public int? ProjectId { get; set; }
    }
}
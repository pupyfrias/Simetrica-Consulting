using System.ComponentModel.DataAnnotations;

namespace SimetricaConsulting.Application.Models.Dtos.V1.Dashboard
{
    public class DashboardCreateDto
    {
        [Required]
        public string UserId { get; set; }

        [Range(1, int.MaxValue)]
        public int TotalTasks { get; set; }

        [Range(1, int.MaxValue)]
        public int CompletedTasks { get; set; }

        [Range(1, int.MaxValue)]
        public int PendingTasks { get; set; }

        [Range(1, int.MaxValue)]
        public int OverdueTasks { get; set; }

        [Range(1, int.MaxValue)]
        public int Projects { get; set; }
    }
}
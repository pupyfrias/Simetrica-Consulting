using System.ComponentModel.DataAnnotations;

namespace SimetricaConsulting.Application.Models.Dtos.V1.Dashboard
{
    public class DashboardUpdateDto
    {

        [Range(1, int.MaxValue)]
        public int Id { get; set; }


        [Range(1,int.MaxValue)]
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
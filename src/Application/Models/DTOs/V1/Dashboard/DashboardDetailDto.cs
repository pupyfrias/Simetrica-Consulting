namespace SimetricaConsulting.Application.Models.Dtos.V1.Dashboard
{
    public class DashboardDetailDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int PendingTasks { get; set; }
        public int OverdueTasks { get; set; }
        public int Projects { get; set; }
    }
}
using SimetricaConsulting.Domain.Common;

namespace SimetricaConsulting.Domain.Entities.V1
{
    public class Dashboard : EntityBase<int>
    {
        public override int Id { get; set; }
        public string UserId { get; set; }
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int PendingTasks { get; set; }
        public int OverdueTasks { get; set; }
        public int Projects { get; set; }

    }

}
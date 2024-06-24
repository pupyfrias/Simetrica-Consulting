namespace SimetricaConsulting.Application.Models.Dtos.V1.Task
{
    public class TaskDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int PriorityId { get; set; }
        public string PriorityName { get; set; }
        public string UserId { get; set; }
        public int? ProjectId { get; set; }
    }
}
using SimetricaConsulting.Domain.Common;

namespace SimetricaConsulting.Domain.Entities.V1
{
    public class Task : EntityBase<int>
    {
        public override int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int PriorityId { get; set; }
        public Priority Priority { get; set; }
        public string UserId { get; set; }
        public int? ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }

}
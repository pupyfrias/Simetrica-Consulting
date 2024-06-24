using SimetricaConsulting.Domain.Common;

namespace SimetricaConsulting.Domain.Entities.V1
{
    public class Comment : EntityBase<int>
    {
        public override int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }

}
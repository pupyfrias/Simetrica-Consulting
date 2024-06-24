using SimetricaConsulting.Domain.Common;

namespace SimetricaConsulting.Domain.Entities.V1
{
    public class Project : EntityBase<int>
    {

        public override int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UserId { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }

}
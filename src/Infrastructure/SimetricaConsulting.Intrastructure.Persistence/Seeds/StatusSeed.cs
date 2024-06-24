using SimetricaConsulting.Domain.Entities.V1;

namespace SimetricaConsulting.Persistence.Seeds
{
    public static class StatusSeed
    {
        public static List<Status> Data { get; } = new List<Status>
    {
        new Status
        {
            Id = 1,
            Name = "Not Started"
        },
        new Status
        {
            Id = 2,
            Name = "In Progress"
        },
        new Status
        {
            Id = 3,
            Name = "Completed"
        }
    };
    }

}

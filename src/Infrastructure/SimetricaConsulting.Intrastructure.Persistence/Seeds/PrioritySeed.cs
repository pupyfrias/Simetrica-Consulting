using SimetricaConsulting.Domain.Entities.V1;

namespace SimetricaConsulting.Persistence.Seeds
{
    public static class PrioritySeed
    {
        public static List<Priority> Data { get; } = new List<Priority>
    {
        new Priority
        {
            Id = 1,
            Name = "Low"
        },
        new Priority
        {
            Id = 2,
            Name = "Medium"
        },
        new Priority
        {
            Id = 3,
            Name = "High"
        }
    };
    }

}

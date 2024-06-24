namespace SimetricaConsulting.Application.Models.Dtos.V1.Project
{
    public class ProjectDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string UserId { get; set; }
        public string User { get; set; }
    }
}
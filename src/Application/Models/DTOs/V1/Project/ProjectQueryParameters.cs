using SimetricaConsulting.Application.Utilities;

namespace SimetricaConsulting.Application.Models.DTOs.V1.Project
{
    public class ProjectQueryParameters: QueryParametersBase
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? UserId { get; set; }
    }
}
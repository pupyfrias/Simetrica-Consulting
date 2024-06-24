using SimetricaConsulting.Application.Utilities;

namespace SimetricaConsulting.Application.Models.Dtos.V1.Task
{
    public class TaskQueryParameters : QueryParametersBase
    {
        public string? UserId { get; set; }
        public int? ProjectId { get; set; }

    }
}
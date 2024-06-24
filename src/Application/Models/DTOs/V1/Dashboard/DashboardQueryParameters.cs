using SimetricaConsulting.Application.Utilities;

namespace SimetricaConsulting.Application.Models.DTOs.V1.Dashboard
{
    public class DashboardQueryParameters : QueryParametersBase
    {
        public string? UserId { get; set; }
    }
}
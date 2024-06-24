using System.ComponentModel.DataAnnotations;

namespace SimetricaConsulting.Application.Models.Dtos.V1.Role
{
    public class RoleIdsDto
    {
        [Required]
        public List<Guid> RoleIds { get; set; }
    }
}
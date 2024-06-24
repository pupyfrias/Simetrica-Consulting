using SimetricaConsulting.Application.Attributes;

namespace SimetricaConsulting.Application.Models.Dtos.V1.Priority
{
    public class PriorityExportDto
    {
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [DisplayName("Creado")]
        public DateTime Created { get; set; }

        [DisplayName("Activo")]
        public bool Active { get; set; }
    }
}
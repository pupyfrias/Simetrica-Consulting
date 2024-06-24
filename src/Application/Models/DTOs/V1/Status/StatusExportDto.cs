using SimetricaConsulting.Application.Attributes;

namespace SimetricaConsulting.Application.Models.Dtos.V1.Status
{
    public class StatusExportDto
    {
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [DisplayName("Creado")]
        public DateTime Created { get; set; }

        [DisplayName("Activo")]
        public bool Active { get; set; }
    }
}
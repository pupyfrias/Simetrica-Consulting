using Microsoft.AspNetCore.Identity;
using SimetricaConsulting.Domain.Entities.V1;
using Task = SimetricaConsulting.Domain.Entities.V1.Task;

namespace SimetricaConsulting.Identity.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Created { get; set; }
        public bool? Active { get; set; }

    }
}
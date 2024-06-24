using System.Text.Json.Serialization;

namespace SimetricaConsulting.Application.Models.Dtos.V1.User
{
    public class UserDetailDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Roles { get; set; }

    }
}
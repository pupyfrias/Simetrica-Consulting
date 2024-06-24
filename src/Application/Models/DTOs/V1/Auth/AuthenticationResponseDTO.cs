using System.Text.Json.Serialization;

namespace SimetricaConsulting.Application.Models.Dtos.V1.Auth
{
    public class AuthenticationResponseDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string AccessToken { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }
    }
}
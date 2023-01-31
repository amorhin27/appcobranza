
namespace AppData.Application.Models.EdentityModel
{
    public class RegistrationRequest
    {
        public string NombreUsuario { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}

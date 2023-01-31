using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Features.Persona.Queries.GetPersonaList
{
    public class PersonaVm
    {
        public int PersonaId { get; set; }
        public string? Dni { get; set; }
        public string? Nombres { get; set; }
        public string? NombreCompleto { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Direccion { get; set; }
        public string? Referencia { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
    }
}

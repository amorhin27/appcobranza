using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.DTOs.PeopleDto
{
    public class GetDniPersonaDTO
    {
        public int PersonaId { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string ApellidoMaterno { get; set; } = string.Empty;
        public string Dni { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
    }
}

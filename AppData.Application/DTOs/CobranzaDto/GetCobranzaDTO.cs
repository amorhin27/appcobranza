using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.DTOs.CobranzaDto
{
    public class GetCobranzaDTO
    {
        public int PersonaId { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string NombreCompleto { get; set;} =string.Empty;
        public string Dni { get; set;} =string.Empty;
        public string Referencia{ get; set;} =string.Empty;
        public string Telefono { get; set;} =string.Empty;
        public decimal DeudaTotal { get; set;}
        public decimal TotalSaldo { get; set;}
        public decimal CobranzaDiario { get; set;}
    }
}

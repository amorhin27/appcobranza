using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.DTOs.CobranzaDto
{
    public class CreateCobranzaDTO
    {
        public int PrestamoId { get; set; }
        public int PersonaId { get; set; }
        public DateTime FechaDescuento { get; set; }
        public decimal MontoDescuento { get; set; }
        public decimal MontoSaldo { get; set; }
        public string Detalle { get; set; } = string.Empty;
        public bool EstadoCobranza { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.DTOs.PrestamoDto
{
    public class CreatePrestamoDTO
    {
        public int PrestamoId { get; set; }
        public int PersonaId { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public string Detalle { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public decimal TasaInteres { get; set; }
        public decimal PagoDiario { get; set; }
        public bool EstadoPrestamo { get; set; }
    }
}

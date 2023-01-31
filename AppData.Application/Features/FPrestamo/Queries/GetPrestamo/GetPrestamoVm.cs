using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Features.FPrestamo.Queries.GetPrestamo
{
    public class GetPrestamoVm
    {
        public int PersonaId { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Dni { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Referencia { get; set; } = string.Empty;
        public decimal TotalCredito { get; set; }
        public string FechaCobranza { get; set; } = string.Empty;
    }
}

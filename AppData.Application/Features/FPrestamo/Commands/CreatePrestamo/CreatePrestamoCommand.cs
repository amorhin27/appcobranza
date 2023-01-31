using AppData.Application.Wrappers;
using AppData.Domain.Comon;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Features.FPrestamo.Commmands.CreatePrestamo
{
    public class CreatePrestamoCommand: EntityModel, IRequest<Response<CreatePrestamoResponse>>
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
    public class CreatePrestamoResponse
    {
        public int Id { get; set; }
    }
}

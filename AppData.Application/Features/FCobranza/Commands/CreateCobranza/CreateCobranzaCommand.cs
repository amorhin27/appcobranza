using AppData.Application.Wrappers;
using AppData.Domain.Comon;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Features.FCobranza.Commands.CreateCobranza
{
    public class CreateCobranzaCommand : EntityModel, IRequest<Response<CreateCobranzaResponse>>
    {
        public int PrestamoId { get; set; }
        public int PersonaId { get; set; }
        public DateTime FechaDescuento { get; set; }
        public decimal MontoDescuento { get; set; }
        public decimal MontoSaldo { get; set; }
        public string Detalle { get; set; } = string.Empty;
        public bool EstadoCobranza { get; set; }
    }
    public class CreateCobranzaResponse
    {
        public int Id { get; set; }
    }
}

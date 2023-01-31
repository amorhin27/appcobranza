using AppData.Application.Contracts.Persistence.ICobranza;
using AppData.Application.DTOs.CobranzaDto;
using AppData.Application.Wrappers;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Features.FCobranza.Commands.CreateCobranza
{
    public class CreateCobranzaCommandHandler : IRequestHandler<CreateCobranzaCommand, Response<CreateCobranzaResponse>>
    {
        private readonly ICobranzaRepository _cobranzaRepository;
        private readonly ILogger<CreateCobranzaCommandHandler> _logger;

        public CreateCobranzaCommandHandler(ICobranzaRepository cobranzaRepository, ILogger<CreateCobranzaCommandHandler> logger)
            => (_cobranzaRepository, _logger) = (cobranzaRepository, logger);
        

        public async Task<Response<CreateCobranzaResponse>> Handle(CreateCobranzaCommand request, CancellationToken cancellationToken)
        {
            CreateCobranzaDTO create = new CreateCobranzaDTO
            {
                PrestamoId = request.PrestamoId,
                PersonaId = request.PersonaId,
                FechaDescuento = request.FechaDescuento,
                MontoDescuento = request.MontoDescuento,
                MontoSaldo = request.MontoSaldo,
                Detalle = request.Detalle,
                EstadoCobranza = request.EstadoCobranza
            };

            int id = await _cobranzaRepository.AddCobranza(create);
            if (id>0)
            {
                return new Response<CreateCobranzaResponse>(new CreateCobranzaResponse { Id = id }, "Se registro correctamente la cobranza");
            }
            else
            {
                return new Response<CreateCobranzaResponse>(new CreateCobranzaResponse { Id = id }, "Error al registrar la cobranza");
            }
        }
    }
}

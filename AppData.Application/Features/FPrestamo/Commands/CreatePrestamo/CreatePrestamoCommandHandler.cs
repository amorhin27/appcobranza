using AppData.Application.Contracts.Persistence.IPrestamo;
using AppData.Application.DTOs.PrestamoDto;
using AppData.Application.Wrappers;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Features.FPrestamo.Commmands.CreatePrestamo
{
    public class CreatePrestamoCommandHandler : IRequestHandler<CreatePrestamoCommand, Response<CreatePrestamoResponse>>
    {
        private readonly IPrestamoRepository _prestamoRepository;
        private readonly ILogger<CreatePrestamoCommandHandler> _logger;

        public CreatePrestamoCommandHandler(IPrestamoRepository prestamoRepository, ILogger<CreatePrestamoCommandHandler> logger)
        {
            _prestamoRepository = prestamoRepository;
            _logger = logger;
        }

        public async Task<Response<CreatePrestamoResponse>> Handle(CreatePrestamoCommand request, CancellationToken cancellationToken)
        {
            /*validar prestamo por persona´pendiente*/

            var newData = await _prestamoRepository.GetPrestamoById(request.PersonaId);
            if (newData.PersonaId == 0 || newData.PersonaId > 0)
            {
                decimal rf = newData.Monto - newData.TotalCredito;
                //decimal rf = newData.Monto - 0;
                //decimal montoFinal = newData.Monto + request.Monto;
                decimal montoFinal = rf + request.Monto;

                CreatePrestamoDTO create = new CreatePrestamoDTO
                {
                    PrestamoId = request.PrestamoId,
                    PersonaId = request.PersonaId,
                    FechaPrestamo = request.FechaPrestamo,
                    Detalle = request.Detalle,
                    Monto = montoFinal,
                    TasaInteres = request.TasaInteres,
                    PagoDiario = request.PagoDiario,
                    EstadoPrestamo = true
                };
                var id = await _prestamoRepository.AddPrestamo(create);
                if (id > 0)
                {
                    return new Response<CreatePrestamoResponse>(new CreatePrestamoResponse { Id = id }, "Se registro correctamente el prestamo.");
                }
                else
                {
                    return new Response<CreatePrestamoResponse>(new CreatePrestamoResponse { Id = id }, "Error al registrar el prestamo.");
                }
            }           
            else
            {
                return new Response<CreatePrestamoResponse>(new CreatePrestamoResponse { Id = 0 }, "No es posible registrar el prestamo.");
            }
        }
    }
}

using AppData.Application.Contracts.Persistence.IPrestamo;
using AppData.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Features.FPrestamo.Queries.GetPrestamo
{
    public class GetPrestamoQueryHandler : IRequestHandler<GetPrestamoQuery, Response<GetPrestamoVm>>
    {
        private readonly IPrestamoRepository _prestamoRepository;

        public GetPrestamoQueryHandler(IPrestamoRepository prestamoRepository)
        {
            _prestamoRepository = prestamoRepository;
        }

        public async Task<Response<GetPrestamoVm>> Handle(GetPrestamoQuery request, CancellationToken cancellationToken)
        {
            var prestamo = await _prestamoRepository.GetPrestamo(request.Dni, request.Nombres, request.Direccion, request.Referencia);
            if (prestamo.Count() > 0)
            {
                GetPrestamoVm vm = new GetPrestamoVm();
                vm.PersonaId = prestamo[0].PersonaId;
                vm.NombreCompleto = prestamo[0].NombreCompleto;
                vm.Dni = prestamo[0].Dni;
                vm.Direccion = prestamo[0].Direccion;
                vm.Referencia = prestamo[0].Referencia;
                vm.TotalCredito = prestamo[0].TotalCredito;
                vm.FechaCobranza = prestamo[0].FechaCobranza;
                return new Response<GetPrestamoVm>(vm,"Busqueda exitosa.");
            }
            else
            {
                return new Response<GetPrestamoVm> ("Cliente con crédito 0.");
            }
        }
    }
}

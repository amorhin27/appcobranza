using AppData.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Features.FPrestamo.Queries.GetPrestamo
{
    public class GetPrestamoQuery : IRequest<Response<GetPrestamoVm>>
    {
        public string? Dni { get; set; }
        public string? Nombres { get; set; }
        public string? Direccion { get; set; }
        public string? Referencia { get; set; }

        public GetPrestamoQuery(string? dni, string? nombres,  string? direccion, string? referencia)
        {
            Dni = dni;
            Nombres = nombres;
            Direccion = direccion;
            Referencia = referencia;
        }
    }
}

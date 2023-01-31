using AppData.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Features.Persona.Queries.GetPersonaList
{
    public class GetPersonaQuery : IRequest<Response<List<PersonaVm>>>
    {
        public string? Nombres { get; set; }
        public string? Dni { get; set; }
        public string? Referencia { get; set; }
        public string? Direccion { get; set; }

        public GetPersonaQuery(string? nombres, string? dni, string? referencia, string? direccion)
        {
            //Nombres = nombres ?? throw new ArgumentException(nameof(nombres));
            Nombres = nombres;
            Dni = dni;
            Referencia = referencia;
            Direccion = direccion;
        }
    }
}

using AppData.Application.Wrappers;
using AppData.Domain.Comon;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Features.FPersonas.Commands.CreatePersona
{
    public class PersonaCommand : EntityModel, IRequest<Response<CreatePersonaResponse>>
    {
        public string? Dni { get; set; }
        public string? Nombres { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Direccion { get; set; }
        public string? Referencia { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        //auditoria
    }

    public class CreatePersonaResponse
    {
        public int Id { get; set; }
        //ublic int id { get; internal set; }
    }
}

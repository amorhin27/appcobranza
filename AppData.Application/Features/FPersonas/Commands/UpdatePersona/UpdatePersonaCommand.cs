using AppData.Application.Wrappers;
using AppData.Domain.Comon;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Features.FPersonas.Commands.UpdatePersona
{
    public class UpdatePersonaCommand : EntityModel, IRequest<Response<UpdatePersonaResponse>>
    {
        public int PersonaId { get; set; }
        public string Dni { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string ApellidoPaterno { get; set; } = string.Empty;
        public string ApellidoMaterno { get; set; } = string.Empty;
        public DateTime? FechaNacimiento { get; set; }
        public string Direccion { get; set; } = string.Empty;
        public string Referencia { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
    }
    public class UpdatePersonaResponse
    {
        public int Id { get; set; }
    }
}

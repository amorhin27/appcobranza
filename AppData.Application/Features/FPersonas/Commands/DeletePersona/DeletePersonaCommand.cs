using AppData.Application.Wrappers;
using AppData.Domain.Comon;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Features.FPersonas.Commands.DeletePersona
{
    public class DeletePersonaCommand : EntityModel, IRequest<Response<DeletePersonaResponse>>
    {
        public int PersonaId { get; set; }

    }

    public class DeletePersonaResponse
    {
        public int Id { get; set; }
    }
}

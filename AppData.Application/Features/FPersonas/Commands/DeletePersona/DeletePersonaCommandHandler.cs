using AppData.Application.Contracts.Peristence;
using AppData.Application.Wrappers;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Features.FPersonas.Commands.DeletePersona
{
    public class DeletePersonaCommandHandler : IRequestHandler<DeletePersonaCommand, Response<DeletePersonaResponse>>
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly ILogger<DeletePersonaCommandHandler> _logger;

        public DeletePersonaCommandHandler(IPersonaRepository personaRepository, ILogger<DeletePersonaCommandHandler> logger)
        {
            _personaRepository = personaRepository;
            _logger = logger;
        }

        public async Task<Response<DeletePersonaResponse>> Handle(DeletePersonaCommand request, CancellationToken cancellationToken)
        {
            //int id = request.PersonaId;
            bool newId = await _personaRepository.DeletePersona(request.PersonaId);

            _logger.LogInformation($"Persona con {request.PersonaId} fue eliminado correctamente.");
            if (newId == true)
            {
                return new Response<DeletePersonaResponse>(new DeletePersonaResponse { Id = request.PersonaId }, "se elimino exitosamente.");
            }
            else
            {
                return new Response<DeletePersonaResponse>(new DeletePersonaResponse { Id = request.PersonaId }, "error al eliminar.");
            }
        }
    }
}

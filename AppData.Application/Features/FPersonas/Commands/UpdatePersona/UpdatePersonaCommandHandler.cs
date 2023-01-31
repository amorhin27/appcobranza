using AppData.Application.Contracts.Peristence;
using AppData.Application.DTOs.PeopleDto;
using AppData.Application.Wrappers;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Features.FPersonas.Commands.UpdatePersona
{
    public class UpdatePersonaCommandHandler : IRequestHandler<UpdatePersonaCommand, Response<UpdatePersonaResponse>>
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly ILogger<UpdatePersonaCommandHandler> _logger;

        public UpdatePersonaCommandHandler(IPersonaRepository personaRepository, ILogger<UpdatePersonaCommandHandler> logger)
        {
            _personaRepository = personaRepository;
            _logger = logger;
        }

        public async Task<Response<UpdatePersonaResponse>> Handle(UpdatePersonaCommand request, CancellationToken cancellationToken)
        {
            //var newData = await _personaRepository.GetPersonaById(request.PersonaId);
            //if (newData.PersonaId == request.PersonaId)
            //{
                UpdatePersonaDTO update = new UpdatePersonaDTO
                {
                    PersonaId = request.PersonaId,
                    Dni = request.Dni,
                    Nombres = request.Nombres,
                    ApellidoPaterno = request.ApellidoPaterno,
                    ApellidoMaterno = request.ApellidoMaterno,
                    FechaNacimiento = request.FechaNacimiento,
                    Direccion = request.Direccion,
                    Referencia = request.Referencia,
                    Telefono = request.Telefono,
                    Correo = request.Correo
                };
                bool result = await _personaRepository.UpdatePerosna(update);
                if (result == true)
                {
                    return new Response<UpdatePersonaResponse>(new UpdatePersonaResponse { Id = request.PersonaId }, "Se actualizo correctamente.");
                }
                else
                {
                    return new Response<UpdatePersonaResponse>(new UpdatePersonaResponse { Id = request.PersonaId }, "No es posible actualizar.");
                }
            //}
            //else
            //{
            //    return new Response<UpdatePersonaResponse>(new UpdatePersonaResponse
            //    {
            //        Id = newData.PersonaId
            //    }, $"El registro no es posible actualizar.");
            //}




            /*La verdad espero que seas muy feliz con la persona
que ahora estás conociendo creeme que intente
de todo por volver a ser parte de tu vida
pero no puedo ser egoísta te deseo lo
mejor entre ustedes dos
que de verdad te haga feliz 
que haga lo que yo jamás pude hacer que siempre
sonrías y brillen tus ojos cada ves que hables de el
que estés enamorada tanto como yo lo estube de tí
gracias por todos los recuerdos que me dejaste
te amo pero tú ya no eres para mí y aunque
me duela el alma...
te tengo que dejar ir porque no hubo cosa que quisiera más 
en este mundo que tu felicidad Adiós amor de mi vida */
        }
    }
}

using AppData.Application.Contracts.Infrastucture;
using AppData.Application.Contracts.Peristence;
using AppData.Application.Models.EmailModels;
using AppData.Application.Wrappers;
using AppData.Domain;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Features.FPersonas.Commands.CreatePersona
{
    public class PersonaCommandHandler : IRequestHandler<PersonaCommand, Response<CreatePersonaResponse>>
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<PersonaCommandHandler> _logger;

        public PersonaCommandHandler(IPersonaRepository personaRepository, IMapper mapper, IEmailService emailService, ILogger<PersonaCommandHandler> logger)
        {
            _personaRepository = personaRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Response<CreatePersonaResponse>> Handle(PersonaCommand request, CancellationToken cancellationToken)
        {
            var personaEntity = _mapper.Map<People>(request);

            var newData = await _personaRepository.GetPersonaDNI(request.Dni);//991863227
            if (newData != null)
            {
                return new Response<CreatePersonaResponse>(new CreatePersonaResponse { Id = newData.PersonaId }, $"Dni {request.Dni} ya existe, registre con otro numero de DNI.");
            }
            else
            {
                var newId = await _personaRepository.AddPersona(personaEntity);
                _logger.LogInformation($"Persona {newId} fue crado exitosamente.");
                await SendEmail(personaEntity);
                if (newId > 0)
                {
                    return new Response<CreatePersonaResponse>(new CreatePersonaResponse { Id = newId }, "fue crado exitosamente.");
                }
                else
                {
                    return new Response<CreatePersonaResponse>(new CreatePersonaResponse { Id = 0 }, "error al crear nueva registro.");
                }
            }

        }

        //public async Task<int> Handle(PersonaCommand request, CancellationToken cancellationToken)
        //{
        //    var personaEntity = _mapper.Map<People>(request);
        //    var newPersona = await _personaRepository.AddPersona(personaEntity);
        //    _logger.LogInformation($"Persona {newPersona} fue crado exitosamente.");
        //    await SendEmail(personaEntity);
        //    return newPersona;
        //}

        private async Task SendEmail(People persona) //empleado remplazar por persona
        {
            var email = new EmailModel
            {
                To = "vari.drez@gmail.com",
                Body = "La compañia de cobranza se creo correctamente",
                Subject = "Mensaje de alerta"
            };
            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception)
            {
                _logger.LogError($"No se puedo enviar el correo {email.To}");
            }
        }
    }
}

using AppData.Application.Contracts.Peristence;
using AppData.Application.Wrappers;
using AutoMapper;
using MediatR;
using System.Collections.Generic;

namespace AppData.Application.Features.Persona.Queries.GetPersonaList
{
    public class GetPersonaQueryHandler : IRequestHandler<GetPersonaQuery, Response<List<PersonaVm>>>
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;

        public GetPersonaQueryHandler(IPersonaRepository personaRepository, IMapper mapper)
        {
            _personaRepository = personaRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<PersonaVm>>> Handle(GetPersonaQuery request, CancellationToken cancellationToken)
        {
            var personaLst = await _personaRepository.GetPersonaAll(request.Nombres, request.Dni, request.Referencia, request.Direccion);
            List<PersonaVm> list = new List<PersonaVm>();
            if (personaLst.Count() > 0)
            {
                foreach (var item in personaLst)
                {
                    PersonaVm list1 = new PersonaVm();
                    list1.PersonaId = item.PersonaId;
                    list1.Dni = item.Dni;
                    list1.NombreCompleto = item.NombreCompleto;
                    list1.Nombres = item.Nombres;
                    list1.ApellidoPaterno = item.ApellidoPaterno;
                    list1.ApellidoMaterno = item.ApellidoMaterno;
                    list1.FechaNacimiento = item.FechaNacimiento;
                    list1.Direccion = item.Direccion;
                    list1.Referencia = item.Referencia;
                    list1.Telefono = item.Telefono;
                    list1.Correo = item.Correo;
                    list.Add(list1);
                }
            }
            return new Response<List<PersonaVm>>(list);
        }
    }
}

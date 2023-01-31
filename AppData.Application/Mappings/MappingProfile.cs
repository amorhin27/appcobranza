using AppData.Application.Features.FPersonas.Commands.CreatePersona;
using AppData.Application.Features.Persona.Queries.GetPersonaList;
using AppData.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<People, PersonaVm>();
            CreateMap<PersonaCommand, People>();            
        }
    }
}

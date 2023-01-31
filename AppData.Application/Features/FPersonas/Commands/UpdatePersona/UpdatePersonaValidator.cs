using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Features.FPersonas.Commands.UpdatePersona
{
    public class UpdatePersonaValidator : AbstractValidator<UpdatePersonaCommand>
    {
        public UpdatePersonaValidator()
        {
            RuleFor(x => x.PersonaId).NotEmpty().NotNull();
        }
    }
}

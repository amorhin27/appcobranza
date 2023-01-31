using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Features.FPersonas.Commands.DeletePersona
{
    public class DeletePersonaValidator : AbstractValidator<DeletePersonaCommand>
    {
        public DeletePersonaValidator() {
            RuleFor(x => x.PersonaId).NotEmpty().NotNull();
        }
    }
}

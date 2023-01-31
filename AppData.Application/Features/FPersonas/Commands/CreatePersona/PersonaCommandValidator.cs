using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Features.FPersonas.Commands.CreatePersona
{
    public class PersonaCommandValidator : AbstractValidator<PersonaCommand>
    {
        public PersonaCommandValidator()
        {
            RuleFor(x=>x.Nombres)
                .MinimumLength(3).WithMessage("{Nombres} minimo 3 caracteres")
                .NotEmpty().WithMessage("{Nombres} no puede estar en blanco")
                .NotNull();

            RuleFor(x => x.Dni)
                .MinimumLength(8).WithMessage("{Dni} minimo 8 caracteres")
                .NotEmpty()
                .NotNull();
        }
    }
}

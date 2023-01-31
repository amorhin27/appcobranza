using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Application.Features.FPrestamo.Commmands.CreatePrestamo
{
    public class CreatePrestamoValidator : AbstractValidator<CreatePrestamoCommand>
    {
        public CreatePrestamoValidator()
        {
            RuleFor(x => x.PersonaId).NotNull().WithMessage("{PropertyName} no puede ser null.");
            RuleFor(x => x.Monto).NotEqual(0).WithMessage("{PropertyName} no puede ser cero.");
        }
    }
}

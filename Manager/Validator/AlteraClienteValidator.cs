using Core.Domain;
using Core.Shared.ModelViews;
using FluentValidation;
using System;

namespace Manager.Validator
{
    public class AlteraClienteValidator : AbstractValidator<AlteraCliente>  
    {
        public AlteraClienteValidator()
        {
            RuleFor(c => c.Id).NotNull().NotEmpty().GreaterThan(0);
            Include(new NovoClienteValidator());
        }
    }
}

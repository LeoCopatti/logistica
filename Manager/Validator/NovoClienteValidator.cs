using Core.Shared.ModelViews;
using FluentValidation;
using System;

namespace Manager.Validator
{
    public class NovoClienteValidator : AbstractValidator<NovoCliente>
    {
        public NovoClienteValidator()
        {
            RuleFor(cliente => cliente.Nome).NotNull().NotEmpty().MinimumLength(3).MaximumLength(150);
            RuleFor(cliente => cliente.DataNascimento).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-200));
            RuleFor(cliente => cliente.Documento).NotNull().NotEmpty().MinimumLength(4).MaximumLength(14);
            RuleFor(cliente => cliente.Telefones).NotNull().NotEmpty();
            RuleFor(cliente => cliente.Sexo).NotNull().NotEmpty().Must(IsMaleOrFemale).WithMessage("O sexo informado deve ser M ou F");            
        }

        private bool IsMaleOrFemale(char sexo)
        {
            return sexo == 'M' || sexo == 'F';
        }
    }
}

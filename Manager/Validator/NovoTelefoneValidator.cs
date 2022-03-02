using Core.Shared.ModelViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Validator
{
    public class NovoTelefoneValidator : AbstractValidator<NovoTelefoneExemplo>
    {
        public NovoTelefoneValidator()
        {
            RuleFor(tel => tel.NumeroTelefone).Matches("[1-9][0-9]{11}").WithMessage("O telefone precisa estar no formato 54912123434");
        }
    }
}

using Core.Shared.ModelViews;
using FluentValidation;

namespace Manager.Validator
{
    public class NovoEnderecoValidator : AbstractValidator<NovoEndereco>
    {
        public NovoEnderecoValidator()
        {
            RuleFor(p => p.Cidade).NotEmpty().NotNull().MaximumLength(300);
        }
    }
}

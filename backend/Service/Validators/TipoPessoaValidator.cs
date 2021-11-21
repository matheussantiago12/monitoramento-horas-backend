using backend.Domain.Entites;
using backend.Service.Validators.Base;
using FluentValidation;

namespace backend.Service.Validators
{
    public class TipoPessoaValidator : BaseValidator<TipoPessoa>
    {
        public TipoPessoaValidator()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("Informe a descrição.")
                .NotNull().WithMessage("Informe a descrição.");
        }
    }
}

using backend.Domain.Entites;
using backend.Service.Validators.Base;
using FluentValidation;

namespace backend.Service.Validators
{
    public class IntegranteEquipeValidator : BaseValidator<IntegranteEquipe>
    {
        public IntegranteEquipeValidator()
        {
            RuleFor(c => c.EquipeId)
                .NotEmpty().WithMessage("Informe a Equipe ID.")
                .NotNull().WithMessage("Informe a Equipe ID.");

            RuleFor(c => c.IntegrantePessoaId)
                .NotEmpty().WithMessage("Informe a Integrante Pessoa ID.")
                .NotNull().WithMessage("Informe a Integrante Pessoa ID.");
        }
    }
}

using backend.Domain.Entites;
using backend.Service.Validators.Base;
using FluentValidation;

namespace backend.Service.Validators
{
    public class EquipeValidator : BaseValidator<Equipe>
    {
        public EquipeValidator()
        {
            RuleFor(c => c.PessoaLiderId)
                .NotEmpty().WithMessage("Informe a Pessoa Lider ID.")
                .NotNull().WithMessage("Informe a Pessoa Lider ID.");

            RuleFor(c => c.SetorId)
                .NotEmpty().WithMessage("Informe o Setor ID.")
                .NotNull().WithMessage("Informe o Setor ID.");
        }
    }
}

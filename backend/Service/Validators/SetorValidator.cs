using backend.Domain.Entites;
using backend.Service.Validators.Base;
using FluentValidation;

namespace backend.Service.Validators
{
    public class SetorValidator : BaseValidator<Setor>
    {
        public SetorValidator()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("Informe a descrição.")
                .NotNull().WithMessage("Informe a descrição.");
        }
    }
}

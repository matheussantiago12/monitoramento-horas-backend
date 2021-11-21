using backend.Domain.Entites;
using backend.Service.Validators.Base;
using FluentValidation;

namespace backend.Service.Validators
{
    public class UsuarioValidator : BaseValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Informe o Email.")
                .NotNull().WithMessage("Informe o Email.");

            RuleFor(c => c.PessoaId)
                .NotEmpty().WithMessage("Informe o Id da Pessoa.")
                .NotNull().WithMessage("Informe o Id da Pessoa.");

            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage("Informe a Senha.")
                .NotNull().WithMessage("Informe a Senha.");
        }
    }
}

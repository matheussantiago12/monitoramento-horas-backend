using backend.Domain.Entites;
using backend.Service.Validators.Base;
using FluentValidation;

namespace backend.Service.Validators
{
    public class ConfiguracaoValidator : BaseValidator<Configuracao>
    {
        public ConfiguracaoValidator()
        {
            RuleFor(c => c.PausaPeriodo)
                .NotEmpty().WithMessage("Informe a Pausa Período.")
                .NotNull().WithMessage("Informe a Pausa Período.");

            RuleFor(c => c.TempoLimiteOciosidade)
                .NotEmpty().WithMessage("Informe o Tempo Limite Ocioso.")
                .NotNull().WithMessage("Informe o Tempo Limite Ocioso.");
        }
    }
}

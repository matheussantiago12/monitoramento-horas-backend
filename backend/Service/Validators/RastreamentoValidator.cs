using backend.Domain.Entites;
using backend.Service.Validators.Base;
using FluentValidation;

namespace backend.Service.Validators
{
    public class RastreamentoValidator : BaseValidator<Rastreamento>
    {
        public RastreamentoValidator()
        {
            RuleFor(c => c.MinutosOcioso)
                .NotEmpty().WithMessage("Informe os Minutos Ociosos.")
                .NotNull().WithMessage("Informe os Minutos Ociosos.");

            RuleFor(c => c.PessoaId)
                .NotEmpty().WithMessage("Informe o Id da Pessoa.")
                .NotNull().WithMessage("Informe o Id da Pessoa.");

            RuleFor(c => c.TempoFinalOciosidade)
                .NotEmpty().WithMessage("Informe o Tempo Final de Ociosidade.")
                .NotNull().WithMessage("Informe o Tempo Final de Ociosidade.");

            RuleFor(c => c.TempoIniciailOciosidade)
                .NotEmpty().WithMessage("Informe o Tempo Inicial de Ociosidade.")
                .NotNull().WithMessage("Informe o Tempo Inicial de Ociosidade.");
        }
    }
}

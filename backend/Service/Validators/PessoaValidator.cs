using backend.Domain.Entites;
using backend.Service.Validators.Base;
using FluentValidation;

namespace backend.Service.Validators
{
    public class PessoaValidator : BaseValidator<Pessoa>
    {
        public PessoaValidator()
        {
            RuleFor(c => c.NomeCompleto)
                .NotEmpty().WithMessage("Informe Nome completo.")
                .NotNull().WithMessage("Informe Nome completo.");
            RuleFor(c => c.HorasTrabalhoDiario)
                .NotEmpty().WithMessage("Informe a Horas Trabalho Diario.")
                .NotNull().WithMessage("Informe Horas Trabalho Diario.");
            RuleFor(c => c.TipoPessoaId)
                .NotEmpty().WithMessage("Informe o Tipo de Pessoa.")
                .NotNull().WithMessage("Informe o Tipo de Pessoa.");
            RuleFor(c => c.Cargo)
                .NotEmpty().WithMessage("Informe o Cargo.")
                .NotNull().WithMessage("Informe o Cargo.");
        }
    }
}

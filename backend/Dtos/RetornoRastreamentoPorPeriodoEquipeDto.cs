using backend.Domain.Entites;

namespace backend.Dtos
{
    public class RetornoRastreamentoPorPeriodoEquipeDto
    {
        public double MediaMinutosOciosos { get; set; }
        public Equipe Equipe { get; set; }
    }
}

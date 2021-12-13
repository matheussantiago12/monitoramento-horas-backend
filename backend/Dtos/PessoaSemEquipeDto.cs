using backend.Domain.Entites;

namespace backend.Dtos
{
    public class PessoaSemEquipeDto
    {
        public PessoaSemEquipeDto(Pessoa pessoa)
        {
            NomeCompleto = pessoa.NomeCompleto;
            Cargo = pessoa.Cargo;
            HorasTrabalhoDiario = pessoa.HorasTrabalhoDiario;
            EquipeId = pessoa.EquipeId;
            TipoPessoaId = pessoa.EquipeId;
            TipoPessoa = pessoa.TipoPessoa;
        }

        public string NomeCompleto { get; set; }
        public string Cargo { get; set; }
        public decimal HorasTrabalhoDiario { get; set; }
        public long EquipeId { get; set; }
        public long TipoPessoaId { get; set; }
        public TipoPessoa TipoPessoa { get; set; }

    }
}

using backend.Domain.Entites;

namespace backend.Dtos
{
    public class PessoaComEquipeSemLiderDto
    {
        public PessoaComEquipeSemLiderDto(Pessoa pessoa)
        {
            NomeCompleto = pessoa.NomeCompleto;
            Cargo = pessoa.Cargo;
            HorasTrabalhoDiario = pessoa.HorasTrabalhoDiario;
            EquipeId = pessoa.EquipeId;
            Equipe = new EquipeSemLider(pessoa.Equipe);
            TipoPessoaId = pessoa.TipoPessoaId;
            TipoPessoa = pessoa.TipoPessoa;
        }

        public string NomeCompleto { get; set; }
        public string Cargo { get; set; }
        public decimal HorasTrabalhoDiario { get; set; }
        public long EquipeId { get; set; }
        public EquipeSemLider Equipe { get; set; }
        public long TipoPessoaId { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
    }
}
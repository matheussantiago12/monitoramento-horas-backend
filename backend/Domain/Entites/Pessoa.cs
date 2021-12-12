using backend.Domain.Entites.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Entites
{
    [Table("pessoa")]
    public class Pessoa : EntityBase
    {
        [Column("nome_completo")]
        public string NomeCompleto { get; set; }
        [Column("cargo")]
        public string Cargo { get; set; }
        [Column("horas_trabalho_diario")]
        public decimal HorasTrabalhoDiario { get; set; }
        [Column("equipe")]
        public Equipe Equipe { get; set; }
        [Column("tipo_pessoa_id")]
        public long TipoPessoaId { get; set; }
        public Setor TipoPessoa { get; set; }
    }
}

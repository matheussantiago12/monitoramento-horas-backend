using backend.Domain.Entites.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Entites
{
    [Table("equipe")]
    public class Equipe : EntityBase
    {
        [Column("pessoa_lider_id")]
        public long PessoaLiderId { get; set; }

        public Pessoa PessoaLider { get; set; }

        [Column("nome")]
        public string Nome { get; set;}

        [Column("setor_id")]
        public long SetorId { get; set; }

        public Setor Setor { get; set; }
    }
}

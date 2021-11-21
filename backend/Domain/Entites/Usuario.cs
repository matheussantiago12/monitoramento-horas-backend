using backend.Domain.Entites.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Entites
{
    [Table("usuario")]
    public class Usuario : EntityBase
    {
        [Column("email")]
        public string Email { get; set; }
        [Column("senha")]
        public string Senha { get; set; }
        [Column("pessoaId")]
        public long PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}

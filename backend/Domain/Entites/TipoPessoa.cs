using backend.Domain.Entites.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Entites
{
    [Table("tipo_pessoa")]
    public class TipoPessoa : EntityBase
    {
        [Column("Descricao")]
        public string Descricao { get; set; }
    }
}

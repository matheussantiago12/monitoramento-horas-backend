using backend.Domain.Entites.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Entites
{
    [Table("setor")]
    public class Setor : EntityBase
    {
        [Column("descricao")]
        public string Descricao { get; set; }
    }
}

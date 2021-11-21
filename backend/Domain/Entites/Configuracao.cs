using backend.Domain.Entites.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Entites
{
    [Table("configuracao")]
    public class Configuracao : EntityBase
    {
        [Column("pausa_periodo")]
        public decimal PausaPeriodo { get; set; }

        [Column("tempo_limite_ociosidade")]
        public decimal TempoLimiteOciosidade { get; set; }
    }
}

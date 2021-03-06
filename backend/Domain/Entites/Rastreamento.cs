using backend.Domain.Entites.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Entites
{
    [Table("rastreamento")]
    public class Rastreamento : EntityBase
    {
        [Column("tempo_inicial_ociosidade")]
        public DateTime TempoInicialOciosidade { get; set; }

        [Column("tempo_final_ociosidade")]
        public DateTime TempoFinalOciosidade { get; set; }

        [Column("pessoa_id")]
        public long PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}

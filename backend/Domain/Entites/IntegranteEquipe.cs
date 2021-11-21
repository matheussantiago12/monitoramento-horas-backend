using backend.Domain.Entites.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Domain.Entites
{
    [Table("integrante_equipe")]
    public class IntegranteEquipe : EntityBase
    {
        [Column("integrante_pessoa_id")]
        public long IntegrantePessoaId { get; set; }
        public Pessoa IntegrantePessoa { get; set; }
        [Column("equipe_id")]
        public long EquipeId { get; set; }
        public Equipe Equipe { get; set; }
    }
}

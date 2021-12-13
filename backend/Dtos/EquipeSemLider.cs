using backend.Domain.Entites;

namespace backend.Dtos
{
    public class EquipeSemLider
    {
        public EquipeSemLider(Equipe equipe)
        {
            PessoaLiderId = equipe.PessoaLiderId;
            Nome = equipe.Nome;
            SetorId = equipe.SetorId;
            Setor = equipe.Setor;
        }
        public long PessoaLiderId { get; set; }

        public string Nome { get; set; }

        public long SetorId { get; set; }

        public Setor Setor { get; set; }
    }
}
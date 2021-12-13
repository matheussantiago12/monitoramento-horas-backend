using backend.Domain.Entites;

namespace backend.Dtos
{
    public class EquipeDto
    {
        public EquipeDto(Equipe equipe)
        {
            PessoaLiderId = equipe.PessoaLiderId;
            PessoaLider = new UsuarioComPessoaSemEquipeDto(equipe.PessoaLider);
            Nome = equipe.Nome;
            SetorId = equipe.SetorId;
            Setor = equipe.Setor;
        }

        public long PessoaLiderId { get; set; }

        public UsuarioComPessoaSemEquipeDto PessoaLider { get; set; }

        public string Nome { get; set;}

        public long SetorId { get; set; }

        public Setor Setor { get; set; }

    }
}

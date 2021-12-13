using backend.Domain.Entites;

namespace backend.Dtos
{
    public class UsuarioComPessoaSemEquipeDto
    {
        public UsuarioComPessoaSemEquipeDto(Usuario usuario)
        {
            Id = usuario.Id;
            Email = usuario.Email;
            Senha = usuario.Senha;
            PessoaId = usuario.PessoaId;
            Pessoa = new PessoaSemEquipeDto(usuario.Pessoa);
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public long PessoaId { get; set; }
        public PessoaSemEquipeDto Pessoa { get; set; }

    }
}

using backend.Domain.Entites;

namespace backend.Dtos
{
    public class UsuarioComPessoaSemEquipeDto
    {
        public UsuarioComPessoaSemEquipeDto(Usuario usuario)
        {
            Email = usuario.Email;
            Senha = usuario.Senha;
            PessoaId = usuario.PessoaId;
            Pessoa = new PessoaSemEquipeDto(usuario.Pessoa);
        }

        public string Email { get; set; }
        public string Senha { get; set; }
        public long PessoaId { get; set; }
        public PessoaSemEquipeDto Pessoa { get; set; }

    }
}

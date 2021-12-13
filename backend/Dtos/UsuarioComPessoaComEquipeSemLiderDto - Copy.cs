using backend.Domain.Entites;

namespace backend.Dtos
{
    public class UsuarioComPessoaComEquipeSemLiderDto
    {
        public UsuarioComPessoaComEquipeSemLiderDto(Usuario usuario)
        {
            Id = usuario.Id;
            Email = usuario.Email;
            Senha = usuario.Senha;
            PessoaId = usuario.PessoaId;
            Pessoa = new PessoaComEquipeSemLiderDto(usuario.Pessoa);
        }
        public long Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public long PessoaId { get; set; }
        public PessoaComEquipeSemLiderDto Pessoa { get; set; }

    }
}

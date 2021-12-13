using backend.Domain.Entites;

namespace backend.Dtos
{
    public class UsuarioCriacaoEdicaoDto
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string NomeCompleto { get; set; }
        public long EquipeId { get; set; }
        public string Cargo { get; set; }
        public long CargaHorariaDiaria { get; set; }
        public long TipoPessoaId { get; set; }
    }
}

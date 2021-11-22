namespace backend.Dtos
{
    public class InputGerarTokenDto
    {
        public InputGerarTokenDto(string email, string cargo, string nomeCompleto)
        {
            Email = email;
            Cargo = cargo;
            NomeCompleto = nomeCompleto;
        }

        public string Email { get; set; }
        public string Cargo { get; set; }
        public string NomeCompleto { get; set; }
    }
}

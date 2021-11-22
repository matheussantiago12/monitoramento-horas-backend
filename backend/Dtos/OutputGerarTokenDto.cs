namespace backend.Dtos
{
    public class OutPutGerarTokenDto
    {
        public OutPutGerarTokenDto(string token)
        {
            Token = token;
        }
        public string Token { get; set; }
    }
}

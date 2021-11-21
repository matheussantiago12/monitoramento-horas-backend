using backend.Domain.Entites;
using System.Collections.Generic;

namespace backend.Dtos
{
    public class IntegrantesEquipeDto
    {
        public Equipe Equipe { get; set; }
        public List<Pessoa> ListaIntegrantes { get; set; }
    }
}

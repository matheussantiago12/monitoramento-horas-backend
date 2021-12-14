using backend.Domain.Entites;
using System.Collections.Generic;

namespace backend.Dtos
{
    public class TempoOciosoTotalERastreamentos
    {
        public double TempoOcioso { get; set; }
        public IEnumerable<Rastreamento> Rastreamentos { get; set; }

    }
}

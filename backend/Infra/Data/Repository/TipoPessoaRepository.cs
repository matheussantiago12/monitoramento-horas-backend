using backend.Domain.Entites;
using backend.Infra.Data.Context;
using backend.Infra.Data.Repository.Base;

namespace backend.Infra.Data.Repository
{
    public class TipoPessoaRepository : BaseRepository<TipoPessoa>
    {
        public TipoPessoaRepository(MonitoramentoHorasContext dbContext) : base(dbContext)
        {
        }
    }
}

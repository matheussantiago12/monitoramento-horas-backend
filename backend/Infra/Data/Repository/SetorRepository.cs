using backend.Domain.Entites;
using backend.Infra.Data.Context;
using backend.Infra.Data.Repository.Base;

namespace backend.Infra.Data.Repository
{
    public class SetorRepository : BaseRepository<Setor>
    {
        public SetorRepository(MonitoramentoHorasContext dbContext) : base(dbContext)
        {
        }
    }
}

using backend.Domain.Entites;
using backend.Infra.Data.Context;
using backend.Infra.Data.Repository.Base;

namespace backend.Infra.Data.Repository
{
    public class ConfiguracaoRepository : BaseRepository<Configuracao>
    {
        public ConfiguracaoRepository(MonitoramentoHorasContext dbContext) : base(dbContext)
        {
        }
    }
}

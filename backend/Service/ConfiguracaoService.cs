using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Service.Services.Base;

namespace backend.Service
{
    public class ConfiguracaoService : BaseService<Configuracao>
    {
        public ConfiguracaoService(IRepository<Configuracao> repository) : base(repository)
        {
        }
    }
}

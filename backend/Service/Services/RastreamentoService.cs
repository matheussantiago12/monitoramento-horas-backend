using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Service.Services.Base;

namespace backend.Service.Services
{
    public class RastreamentoService : BaseService<Rastreamento>
    {
        public RastreamentoService(IRepository<Rastreamento> repository) : base(repository)
        {
        }
    }
}

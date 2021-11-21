using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Service.Services.Base;

namespace backend.Service.Services
{
    public class SetorService : BaseService<Setor>
    {
        public SetorService(IRepository<Setor> repository) : base(repository)
        {
        }
    }
}

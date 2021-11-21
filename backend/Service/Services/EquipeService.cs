using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Service.Services.Base;

namespace backend.Service.Services
{
    public class EquipeService : BaseService<Equipe>
    {
        public EquipeService(IRepository<Equipe> repository) : base(repository)
        {
        }
    }
}

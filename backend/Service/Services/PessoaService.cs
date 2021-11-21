using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Service.Services.Base;

namespace backend.Service.Services
{
    public class PessoaService : BaseService<Pessoa>
    {
        public PessoaService(IRepository<Pessoa> repository) : base(repository)
        {
        }
    }
}

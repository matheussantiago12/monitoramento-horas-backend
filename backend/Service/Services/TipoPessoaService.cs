using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Service.Services.Base;

namespace backend.Service.Services
{
    public class TipoPessoaService : BaseService<TipoPessoa>
    {
        public TipoPessoaService(IRepository<TipoPessoa> repository) : base(repository)
        {
        }
    }
}

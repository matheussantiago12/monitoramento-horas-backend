using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Service.Services.Base;

namespace backend.Service.Services
{
    public class UsuarioService : BaseService<Usuario>
    {
        public UsuarioService(IRepository<Usuario> repository) : base(repository)
        {
        }
    }
}

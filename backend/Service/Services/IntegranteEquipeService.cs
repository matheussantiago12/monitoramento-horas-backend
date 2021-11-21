using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Dtos;
using backend.Infra.Data.Repository;
using backend.Service.Services.Base;

namespace backend.Service.Services
{
    public class IntegranteEquipeService : BaseService<IntegranteEquipe>
    {
        private readonly IntegranteEquipeRepository _integranteEquipeRepository;
        public IntegranteEquipeService(IRepository<IntegranteEquipe> repository) : base(repository)
        {
            _integranteEquipeRepository = (IntegranteEquipeRepository)repository;
        }

        public IntegrantesEquipeDto GetAllMembers(long equipeId)
        {
            return _integranteEquipeRepository.GetAllMembers(equipeId);
        }
    }
}

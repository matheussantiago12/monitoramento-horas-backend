using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Infra.Data.Repository;
using backend.Service.Services.Base;
using System;
using System.Collections.Generic;

namespace backend.Service.Services
{
    public class EquipeService : BaseService<Equipe>
    {
        private readonly EquipeRepository _equipeRepository;
        public EquipeService(IRepository<Equipe> repository) : base(repository)
        {
            _equipeRepository = (EquipeRepository)repository;
        }

        public IEnumerable<Equipe> GetAllLikeNome(string nome)
        {
            return _equipeRepository.GetAllLikeNome(nome);
        }

        public IEnumerable<Equipe> GetBySetorId(long idSetor)
        {
            return _equipeRepository.GetBySetorId(idSetor);
        }
    }
}

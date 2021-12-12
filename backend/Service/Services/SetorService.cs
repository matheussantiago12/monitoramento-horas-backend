using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Infra.Data.Repository;
using backend.Service.Services.Base;
using System;
using System.Collections.Generic;

namespace backend.Service.Services
{
    public class SetorService : BaseService<Setor>
    {
        private readonly SetorRepository _setorRepository;
        public SetorService(IRepository<Setor> repository) : base(repository)
        {
            _setorRepository = (SetorRepository)repository;
        }

        public IEnumerable<Setor> GetAllLikeNome(string nome)
        {
            return _setorRepository.GetAllLikeNome(nome);
        }
    }
}

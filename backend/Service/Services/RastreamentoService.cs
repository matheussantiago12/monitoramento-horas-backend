using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Infra.Data.Repository;
using backend.Service.Services.Base;
using System;
using System.Collections.Generic;

namespace backend.Service.Services
{
    public class RastreamentoService : BaseService<Rastreamento>
    {
        private readonly RastreamentoRepository _rastreamentoRepository;
        public RastreamentoService(RastreamentoRepository repository) : base(repository)
        {
            _rastreamentoRepository = repository;
        }
        public IEnumerable<Rastreamento> GetRastreamentoPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return _rastreamentoRepository.GetRastreamentoPorPeriodo(dataInicio, dataFim);
        }

        public IEnumerable<Rastreamento> GetRastreamentoPorSetorPeriodo(DateTime dataInicio, DateTime dataFim, int setorId)
        {
            return _rastreamentoRepository.GetRastreamentoPorSetorPeriodo(dataInicio, dataFim, setorId);
        }

        public IEnumerable<Rastreamento> GetRastreamentoPorEquipePeriodo(DateTime dataInicio, DateTime dataFim, int equipeId)
        {
            return _rastreamentoRepository.GetRastreamentoPorEquipePeriodo(dataInicio, dataFim, equipeId);
        }

        public IEnumerable<Rastreamento> GetRastreamentoPorPessoaPeriodo(DateTime dataInicio, DateTime dataFim, int pessoaId)
        {
            return _rastreamentoRepository.GetRastreamentoPorPessoaPeriodo(dataInicio, dataFim, pessoaId);
        }
    }
}

using backend.Domain.Entites;
using backend.Infra.Data.Context;
using backend.Infra.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace backend.Infra.Data.Repository
{
    public class RastreamentoRepository : BaseRepository<Rastreamento>
    {
        public RastreamentoRepository(MonitoramentoHorasContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<Rastreamento> GetAll()
        {
            return _dbContext.Set<Rastreamento>().Include(p => p.Pessoa).Include(p => p.Pessoa.TipoPessoa).ToList();
        }

        public override Rastreamento GetById(long id)
        {
            return _dbContext.Set<Rastreamento>().Include(u => u.Pessoa).Include(p => p.Pessoa.TipoPessoa).ToList().Find(rastreamento => rastreamento.Id == id);
        }

        internal IEnumerable<Rastreamento> GetRastreamentoPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return _dbContext.Rastreamentos.Where(r => r.TempoInicialOciosidade >= dataInicio && r.TempoInicialOciosidade <= dataFim && r.TempoFinalOciosidade <= dataFim).ToList();
        }

        public IEnumerable<Rastreamento> GetRastreamentoPorSetorPeriodo(DateTime dataInicio, DateTime dataFim, int setorId)
        {
            return _dbContext.Rastreamentos.Where(r => r.Pessoa.Equipe.SetorId == setorId && r.TempoInicialOciosidade >= dataInicio && r.TempoInicialOciosidade <= dataFim && r.TempoFinalOciosidade <= dataFim).ToList();
        }

        internal IEnumerable<Rastreamento> GetRastreamentoPorPessoaPeriodo(DateTime dataInicio, DateTime dataFim, int pessoaId)
        {
            return _dbContext.Rastreamentos.Where(r => r.PessoaId == pessoaId && r.TempoInicialOciosidade >= dataInicio && r.TempoInicialOciosidade <= dataFim && r.TempoFinalOciosidade <= dataFim).ToList();
        }

        internal IEnumerable<Rastreamento> GetRastreamentoPorEquipePeriodo(DateTime dataInicio, DateTime dataFim, int equipeId)
        {
            return _dbContext.Rastreamentos.Where(r => r.Pessoa.Equipe.Id == equipeId && r.TempoInicialOciosidade >= dataInicio && r.TempoInicialOciosidade <= dataFim && r.TempoFinalOciosidade <= dataFim).ToList();
        }
    }
}

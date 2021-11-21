using backend.Domain.Entites;
using backend.Infra.Data.Context;
using backend.Infra.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
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
    }
}

using backend.Domain.Entites;
using backend.Infra.Data.Context;
using backend.Infra.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace backend.Infra.Data.Repository
{
    public class PessoaRepository : BaseRepository<Pessoa>
    {
        public PessoaRepository(MonitoramentoHorasContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<Pessoa> GetAll()
        {
            return _dbContext.Set<Pessoa>().Include(p => p.TipoPessoa).ToList();
        }

        public override Pessoa GetById(long id)
        {
            return _dbContext.Set<Pessoa>().Include(p => p.TipoPessoa).ToList().Find(pessoa => pessoa.Id == id);
        }
    }
}

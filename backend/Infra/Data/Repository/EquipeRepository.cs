using backend.Domain.Entites;
using backend.Infra.Data.Context;
using backend.Infra.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace backend.Infra.Data.Repository
{
    public class EquipeRepository : BaseRepository<Equipe>
    {
        public EquipeRepository(MonitoramentoHorasContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<Equipe> GetAll()
        {
            return _dbContext.Set<Equipe>().Include(e => e.PessoaLider).Include(e => e.PessoaLider.TipoPessoa).Include(e => e.Setor).ToList();
        }

        public override Equipe GetById(long id)
        {
            return _dbContext.Set<Equipe>().Include(e => e.PessoaLider).Include(e => e.PessoaLider.TipoPessoa).Include(e => e.Setor).ToList().Find(equipe => equipe.Id == id);
        }

        public IEnumerable<Equipe> GetBySetorId(long idSetor)
        {
            return _dbContext.Set<Equipe>()
                .Include(e => e.PessoaLider)
                .Include(e => e.PessoaLider.TipoPessoa)
                .Include(e => e.Setor)
                .Where(equipe => equipe.SetorId == idSetor)
                .ToList();
        }
    }
}

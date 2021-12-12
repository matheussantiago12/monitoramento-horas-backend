using backend.Domain.Entites;
using backend.Infra.Data.Context;
using backend.Infra.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
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

        public IEnumerable<Equipe> GetAllLikeNome(string nome)
        {
            return _dbContext.Equipes.Where(e => e.Nome.Contains(nome)).Include(e => e.PessoaLider).Include(e => e.PessoaLider.TipoPessoa).Include(e => e.Setor);
        }
    }
}

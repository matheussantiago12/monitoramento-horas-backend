using backend.Domain.Entites;
using backend.Infra.Data.Context;
using backend.Infra.Data.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace backend.Infra.Data.Repository
{
    public class SetorRepository : BaseRepository<Setor>
    {
        public SetorRepository(MonitoramentoHorasContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Setor> GetAllLikeNome(string nome)
        {
            return _dbContext.Setors.Where(s => s.Descricao.Contains(nome));
        }
    }
}

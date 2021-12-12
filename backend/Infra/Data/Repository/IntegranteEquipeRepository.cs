using backend.Domain.Entites;
using backend.Dtos;
using backend.Infra.Data.Context;
using backend.Infra.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace backend.Infra.Data.Repository
{
    public class IntegranteEquipeRepository : BaseRepository<IntegranteEquipe>
    {
        public IntegranteEquipeRepository(MonitoramentoHorasContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<IntegranteEquipe> GetAll()
        {
            return _dbContext.Set<IntegranteEquipe>()
                .Include(i => i.IntegrantePessoa)
                .Include(i => i.IntegrantePessoa.TipoPessoa)
                .Include(i => i.Equipe)
                .Include(i => i.Equipe.PessoaLider)
                .Include(i => i.Equipe.PessoaLider.Pessoa.TipoPessoa)
                .Include(i => i.Equipe.Setor).ToList();
        }

        public override IntegranteEquipe GetById(long id)
        {
            return _dbContext.Set<IntegranteEquipe>()
                 .Include(i => i.IntegrantePessoa)
                 .Include(i => i.IntegrantePessoa.TipoPessoa)
                 .Include(i => i.Equipe)
                 .Include(i => i.Equipe.PessoaLider)
                 .Include(i => i.Equipe.PessoaLider.Pessoa.TipoPessoa)
                 .Include(i => i.Equipe.Setor).ToList()
                 .Find(i => i.Id == id);
        }

        public IntegrantesEquipeDto GetAllMembers(long equipeId)
        {
            var members = _dbContext.Set<IntegranteEquipe>()
                .Include(i => i.IntegrantePessoa)
                .Include(i => i.IntegrantePessoa.TipoPessoa)
                .Include(i => i.Equipe)
                .Include(i => i.Equipe.PessoaLider)
                .Include(i => i.Equipe.PessoaLider.Pessoa.TipoPessoa)
                .Include(i => i.Equipe.Setor)
                .Where(i => i.EquipeId == equipeId)
                .ToList();

            IntegrantesEquipeDto dto = new IntegrantesEquipeDto();

            List<Pessoa> integrantes = new List<Pessoa>();
            members.ForEach(m => {
                integrantes.Add(m.IntegrantePessoa);
            });

            dto.ListaIntegrantes = integrantes;
            dto.Equipe = members.First().Equipe;

            return dto;
        }
    }
}

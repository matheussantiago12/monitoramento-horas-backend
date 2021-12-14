using backend.Domain.Entites;
using backend.Infra.Data.Context;
using backend.Infra.Data.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace backend.Infra.Data.Repository
{
    public class UsuarioRepository : BaseRepository<Usuario>
    {
        public UsuarioRepository(MonitoramentoHorasContext dbContext) : base(dbContext)
        {
        }

        public override IEnumerable<Usuario> GetAll()
        {
            return _dbContext.Set<Usuario>().Include(p => p.Pessoa).Include(p => p.Pessoa.TipoPessoa).Include(u => u.Pessoa.Equipe).Include(u => u.Pessoa.Equipe.PessoaLider).Include(u => u.Pessoa.Equipe.Setor).ToList();
        }

        public override Usuario GetById(long id)
        {
            return _dbContext.Set<Usuario>().Include(u => u.Pessoa).Include(p => p.Pessoa.TipoPessoa).Include(u => u.Pessoa.Equipe).Include(u => u.Pessoa.Equipe.PessoaLider).Include(u => u.Pessoa.Equipe.Setor).ToList().Find(usuario => usuario.Id == id);
        }

        public Usuario ValidarCredenciais(string email, string senha)
        {
            return _dbContext.Usuarios.Where(usuario => usuario.Email.ToLower() == email.ToLower() && usuario.Senha.ToLower() == senha.ToLower()).Include(p => p.Pessoa).FirstOrDefault();
        }

        public IEnumerable<Usuario> GetAllLikeNome(string nome)
        {
            return _dbContext.Usuarios.Where(u => u.Pessoa.NomeCompleto.Contains(nome)).Include(p => p.Pessoa).Include(p => p.Pessoa.TipoPessoa).Include(u => u.Pessoa.Equipe).Include(u => u.Pessoa.Equipe.PessoaLider).Include(u => u.Pessoa.Equipe.Setor);
        }

        public IEnumerable<Usuario> GetUsuariosLideres()
        {
            return _dbContext.Usuarios.Where(u => u.Pessoa.TipoPessoaId == 2).Include(p => p.Pessoa).Include(p => p.Pessoa.TipoPessoa).Include(u => u.Pessoa.Equipe).Include(u => u.Pessoa.Equipe.PessoaLider).Include(u => u.Pessoa.Equipe.Setor).ToList();
        }

        public IEnumerable<Usuario> GetPorEmail(string email)
        {
            return _dbContext.Usuarios.Where(u => u.Email == email).Include(p => p.Pessoa).Include(p => p.Pessoa.TipoPessoa).Include(u => u.Pessoa.Equipe).Include(u => u.Pessoa.Equipe.PessoaLider).Include(u => u.Pessoa.Equipe.Setor);
        }

        public IEnumerable<Usuario> GetByEquipeId(long equipeId)
        {
            return _dbContext.Usuarios
                .Where(u => u.Pessoa.EquipeId == equipeId)
                .Include(p => p.Pessoa)
                .Include(p => p.Pessoa.TipoPessoa)
                .Include(u => u.Pessoa.Equipe)
                .Include(u => u.Pessoa.Equipe.PessoaLider).Include(u => u.Pessoa.Equipe.Setor);
        }
    }
}

﻿using backend.Domain.Entites;
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
            return _dbContext.Set<Usuario>().Include(p => p.Pessoa).Include(p => p.Pessoa.TipoPessoa).ToList();
        }

        public override Usuario GetById(long id)
        {
            return _dbContext.Set<Usuario>().Include(u => u.Pessoa).Include(p => p.Pessoa.TipoPessoa).ToList().Find(usuario => usuario.Id == id);
        }

        public Usuario ValidarCredenciais(string email, string senha)
        {
            return _dbContext.Set<Usuario>()
                .Include(p => p.Pessoa)
                .ToList()
                .Find(usuario => usuario.Email.ToLower() == email.ToLower() && usuario.Senha.ToLower() == senha.ToLower());
        }
        public IEnumerable<Usuario> GetAllLikeNome(string nome)
        {
            return _dbContext.Usuarios.Where(u => u.Pessoa.NomeCompleto.Contains(nome)).Include(p => p.Pessoa).Include(p => p.Pessoa.TipoPessoa);
        }

        public IEnumerable<Usuario> GetPorEmail(string email)
        {
            return _dbContext.Usuarios.Where(u => u.Email == email);
        }
    }
}

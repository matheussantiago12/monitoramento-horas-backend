﻿using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Dtos;
using backend.Infra.Data.Repository;
using backend.Service.Services.Base;

namespace backend.Service.Services
{
    public class UsuarioService : BaseService<Usuario>
    {
        private readonly UsuarioRepository _usuarioRepository;
        public UsuarioService(IRepository<Usuario> repository) : base(repository)
        {
            _usuarioRepository = (UsuarioRepository)repository;
        }

        public InputGerarTokenDto ValidarCredenciais(string email, string senha)
        {
            Usuario usuario = _usuarioRepository.ValidarCredenciais(email, senha);
            if (usuario == null)
            {
                return null;
            }

            return new InputGerarTokenDto(
                usuario.Pessoa.NomeCompleto,
                usuario.Pessoa.Cargo,
                usuario.Email);
        }
    }
}
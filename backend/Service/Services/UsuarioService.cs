using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Dtos;
using backend.Infra.Data.Repository;
using backend.Service.Services.Base;
using System;
using System.Collections.Generic;

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
                usuario.Email,
                usuario.Pessoa.Cargo,
                usuario.Pessoa.NomeCompleto);
        }

        public IEnumerable<Usuario> GetAllLikeNome(string nome)
        {
            return _usuarioRepository.GetAllLikeNome(nome);
        }

        public Usuario GetPorEmail(string email)
        {
            return _usuarioRepository.GetPorEmail(email);
        }

        public IEnumerable<Usuario> GetUsuariosLideres()
        {
            return _usuarioRepository.GetUsuariosLideres();
        }

        public IEnumerable<Usuario> GetByEquipeId(long equipeId)
        {
            return _usuarioRepository.GetByEquipeId(equipeId);
        }

    }
}

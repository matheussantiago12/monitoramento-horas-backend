using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Dtos;
using backend.Service.Services;
using backend.Service.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace backend.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly UsuarioService usuarioService;
        private readonly PessoaService pessoaService;
        public UsuarioController(IService<Usuario> _usuarioService, IService<Pessoa> _pessoaService)
        {
            this.usuarioService = (UsuarioService)_usuarioService;
            this.pessoaService = (PessoaService)_pessoaService;
        }

        [HttpPost("validar-credenciais")]
        public ActionResult<dynamic> ValidarCrendenciais([FromBody] UsuarioValidarCredenciasDto dto)
        {
            if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Senha))
            {
                return BadRequest();
            }

            InputGerarTokenDto informacaoToken = usuarioService.ValidarCredenciais(dto.Email, dto.Senha);
            if (informacaoToken == null)
            {
                return Unauthorized(new { message = "Usuário ou senha inválidos" });
            }

            string token = TokenService.GerarToken(informacaoToken);
            return new OutPutGerarTokenDto(token);
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<UsuarioComPessoaComEquipeSemLiderDto>> GetAll()
        {
            var usuarios = usuarioService.Get().ToList();
            var listaDto = new List<UsuarioComPessoaComEquipeSemLiderDto>();

            foreach (var usuario in usuarios)
            {
                listaDto.Add(new UsuarioComPessoaComEquipeSemLiderDto(usuario));
            }

            return listaDto;
        }

        [HttpGet("lideres")]
        [Authorize]
        public ActionResult<IEnumerable<UsuarioComPessoaSemEquipeDto>> GetUsuariosLideres()
        {
            var usuarios = usuarioService.GetUsuariosLideres().ToList();
            var listaDto = new List<UsuarioComPessoaSemEquipeDto>();

            foreach (var usuario in usuarios)
            {
                listaDto.Add(new UsuarioComPessoaSemEquipeDto(usuario));
            }

            return listaDto;
        }

        [HttpGet("logado")]
        public ActionResult<Usuario> GetLogado([FromHeader] string authorization)
        {
            var token = authorization.Split(" ");
            var email = TokenService.ObterActor(token[1] ?? authorization);
            return Ok(usuarioService.GetPorEmail(email));
        }

        [HttpGet("PorNome")]
        [Authorize]
        public ActionResult<IEnumerable<UsuarioComPessoaComEquipeSemLiderDto>> GetAllLikeNome(string nome)
        {
            var usuarios = usuarioService.GetAllLikeNome(nome).ToList();
            var listaDto = new List<UsuarioComPessoaComEquipeSemLiderDto>();

            foreach (var usuario in usuarios)
            {
                listaDto.Add(new UsuarioComPessoaComEquipeSemLiderDto(usuario));
            }

            return listaDto;
        }

        [HttpGet("buscar-equipe/{equipeId}")]
        [Authorize]
        public ActionResult<IEnumerable<UsuarioComPessoaComEquipeSemLiderDto>> GetByEquipe(long equipeId)
        {
            var usuarios = usuarioService.GetByEquipeId(equipeId).ToList();
            var listaDto = new List<UsuarioComPessoaComEquipeSemLiderDto>();

            foreach (var usuario in usuarios)
            {
                listaDto.Add(new UsuarioComPessoaComEquipeSemLiderDto(usuario));
            }

            return listaDto;
        }

        [HttpGet("{id}")]
        public ActionResult<UsuarioComPessoaComEquipeSemLiderDto> GetById(long id)
        {
            if (ModelState.IsValid)
            {
                return new UsuarioComPessoaComEquipeSemLiderDto(usuarioService.Get(id));
            }
            return BadRequest();
        }

        [HttpPost]
        [Authorize]
        public void Post([FromBody] UsuarioCriacaoEdicaoDto usuarioModel)
        {
            if (ModelState.IsValid)
            {
                var pessoa = new Pessoa()
                {
                    Cargo = usuarioModel.Cargo,
                    EquipeId = usuarioModel.EquipeId,
                    HorasTrabalhoDiario = usuarioModel.CargaHorariaDiaria,
                    NomeCompleto = usuarioModel.NomeCompleto,
                    TipoPessoaId = usuarioModel.TipoPessoaId
                };
                var pessoaCriada = pessoaService.Post<PessoaValidator>(pessoa);

                var usuario = new Usuario()
                {
                    Email = usuarioModel.Email,
                    Senha = usuarioModel.Senha,
                    PessoaId = pessoaCriada.Id
                };

                usuarioService.Post<UsuarioValidator>(usuario);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public void Put(long id, [FromBody] UsuarioCriacaoEdicaoDto usuarioModel)
        {
            if (id <= 0)
                NotFound();

            if (ModelState.IsValid)
            {
                var usuario = usuarioService.Get(id);
                var pessoa = pessoaService.Get(usuario.PessoaId);

                usuario.Email = usuarioModel.Email;
                usuario.Senha = usuarioModel.Senha;
                pessoa.Cargo = usuarioModel.Cargo;
                pessoa.EquipeId = usuarioModel.EquipeId;
                pessoa.HorasTrabalhoDiario = usuarioModel.CargaHorariaDiaria;
                pessoa.NomeCompleto = usuarioModel.NomeCompleto;
                pessoa.TipoPessoaId = usuarioModel.TipoPessoaId;

                pessoaService.Put<PessoaValidator>(pessoa);
                usuarioService.Put<UsuarioValidator>(usuario);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(long id)
        {
            if (id <= 0)
                NotFound();

            usuarioService.Delete(id);
        }
    }
}

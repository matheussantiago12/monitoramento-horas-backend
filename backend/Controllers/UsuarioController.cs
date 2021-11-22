using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Dtos;
using backend.Service.Services;
using backend.Service.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly UsuarioService usuarioService;
        public UsuarioController(IService<Usuario> _usuarioService)
        {
            this.usuarioService = (UsuarioService)_usuarioService;
        }

        [HttpPost("/validar-credenciais")]
        public ActionResult<dynamic> ValidarCrendenciais([FromBody] UsuarioValidarCredenciasDto dto)
        {
            if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Senha))
            {
                return BadRequest();
            }

            InputGerarTokenDto informacaoToken = usuarioService.ValidarCredenciais(dto.Email, dto.Senha);
            if (informacaoToken == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }

            string token = TokenService.GerarToken(informacaoToken);
            return new OutPutGerarTokenDto(token);
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Usuario>> GetAll()
        {
            return usuarioService.Get().ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Usuario> GetById(long id)
        {
            if (ModelState.IsValid)
            {
                return usuarioService.Get(id);
            }
            return BadRequest();
        }
        [HttpPost]
        [Authorize]
        public void Post([FromBody] Usuario usuarioModel)
        {
            if (ModelState.IsValid)
            {
                usuarioService.Post<UsuarioValidator>(usuarioModel);
            }
        }
        [HttpPut("{id}")]
        [Authorize]
        public void Put(long id, [FromBody] Usuario usuarioModel)
        {
            if (id <= 0)
                NotFound();

            if (ModelState.IsValid)
            {
                Usuario usuario = usuarioService.Get(id);
                usuario.Email = usuarioModel.Email;
                usuario.Senha = usuarioModel.Senha;
                usuario.PessoaId = usuarioModel.PessoaId;

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

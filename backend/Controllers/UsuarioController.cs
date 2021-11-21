using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IService<Usuario> usuarioService;
        public UsuarioController(IService<Usuario> _usuarioService)
        {
            this.usuarioService = _usuarioService;
        }
        [HttpGet]
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
        public void Post([FromBody] Usuario usuarioModel)
        {
            if (ModelState.IsValid)
            {
                usuarioService.Post<UsuarioValidator>(usuarioModel);
            }
        }
        [HttpPut("{id}")]
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
        public void Delete(long id)
        {
            if (id <= 0)
                NotFound();

            usuarioService.Delete(id);
        }
    }
}

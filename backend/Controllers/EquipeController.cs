using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Service.Services;
using backend.Service.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers
{
    [Route("api/equipe")]
    [ApiController]
    public class EquipeController : Controller
    {
        private readonly EquipeService equipeService;
        public EquipeController(IService<Equipe> _equipeService)
        {
            this.equipeService = (EquipeService)_equipeService;
        }
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Equipe>> GetAll()
        {
            return equipeService.Get().ToList();
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Equipe>> GetAllLikeNome(string nome)
        {
            return equipeService.GetAllLikeNome(nome).ToList();
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Equipe> GetById(long id)
        {
            if (ModelState.IsValid)
            {
                return equipeService.Get(id);
            }
            return BadRequest();
        }
        [HttpPost]
        [Authorize]
        public void Post([FromBody] Equipe equipeModel)
        {
            if (ModelState.IsValid)
            {
                equipeService.Post<EquipeValidator>(equipeModel);
            }
        }
        [HttpPut("{id}")]
        [Authorize]
        public void Put(long id, [FromBody] Equipe equipeModel)
        {
            if (id <= 0)
                NotFound();

            if (ModelState.IsValid)
            {
                Equipe equipe = equipeService.Get(id);
                equipe.PessoaLiderId = equipeModel.PessoaLiderId;
                equipe.SetorId = equipeModel.SetorId;

                equipeService.Put<EquipeValidator>(equipe);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(long id)
        {
            if (id <= 0)
                NotFound();

            equipeService.Delete(id);
        }
    }
}

using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Dtos;
using backend.Service.Services;
using backend.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers
{
    [Route("api/integrante-equipe")]
    [ApiController]
    public class IntegranteEquipeController : Controller
    {
        private readonly IntegranteEquipeService integranteEquipeService;
        public IntegranteEquipeController(IService<IntegranteEquipe> _integranteEquipeService)
        {
            this.integranteEquipeService = (IntegranteEquipeService)_integranteEquipeService;
        }

        [HttpGet("/integrantes-equipe/{idEquipe}")]
        public ActionResult<IntegrantesEquipeDto> GetAllMembers(long idEquipe)
        {
            return integranteEquipeService.GetAllMembers(idEquipe);
        }


        [HttpGet]
        public ActionResult<IEnumerable<IntegranteEquipe>> GetAll()
        {
            return integranteEquipeService.Get().ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<IntegranteEquipe> GetById(long id)
        {
            if (ModelState.IsValid)
            {
                return integranteEquipeService.Get(id);
            }
            return BadRequest();
        }
        [HttpPost]
        public void Post([FromBody] IntegranteEquipe integranteEquipeModel)
        {
            if (ModelState.IsValid)
            {
                integranteEquipeService.Post<IntegranteEquipeValidator>(integranteEquipeModel);
            }
        }
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] IntegranteEquipe integranteEquipeModel)
        {
            if (id <= 0)
                NotFound();

            if (ModelState.IsValid)
            {
                IntegranteEquipe integranteEquipe = integranteEquipeService.Get(id);
                integranteEquipe.EquipeId = integranteEquipeModel.EquipeId;
                integranteEquipe.IntegrantePessoaId = integranteEquipeModel.IntegrantePessoaId;

                integranteEquipeService.Put<IntegranteEquipeValidator>(integranteEquipe);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            if (id <= 0)
                NotFound();

            integranteEquipeService.Delete(id);
        }
    }
}

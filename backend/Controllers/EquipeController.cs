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
        public ActionResult<IEnumerable<EquipeDto>> GetAll()
        {
            var equipes = equipeService.Get().ToList();
            var listaDto = new List<EquipeDto>();
            foreach (var equipe in equipes)
            {
                listaDto.Add(new EquipeDto(equipe));
            }
            return listaDto;
        }

        [HttpGet("PorNome")]
        [Authorize]
        public ActionResult<IEnumerable<EquipeDto>> GetAllLikeNome(string nome)
        {
            var equipes = equipeService.GetAllLikeNome(nome).ToList();
            var listaDto = new List<EquipeDto>();
            foreach (var equipe in equipes)
            {
                listaDto.Add(new EquipeDto(equipe));
            }
            return listaDto;
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<EquipeDto> GetById(long id)
        {
            if (ModelState.IsValid)
            {
                return new EquipeDto(equipeService.Get(id));
            }
            return BadRequest();
        }

        [HttpGet("buscar-setor/{idSetor}")]
        [Authorize]
        public ActionResult<IEnumerable<Equipe>> GetBySetorId(long idSetor)
        {
            if (idSetor > 0)
            {
                return equipeService.GetBySetorId(idSetor).ToList();
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
                equipe.Nome = equipeModel.Nome;
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

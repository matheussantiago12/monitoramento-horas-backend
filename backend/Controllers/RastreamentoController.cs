using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers
{
    [Route("api/rastreamento")]
    [ApiController]
    public class RastreamentoController : Controller
    {
        private readonly IService<Rastreamento> rastreamentoService;
        public RastreamentoController(IService<Rastreamento> _rastreamentoService)
        {
            this.rastreamentoService = _rastreamentoService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Rastreamento>> GetAll()
        {
            return rastreamentoService.Get().ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Rastreamento> GetById(long id)
        {
            if (ModelState.IsValid)
            {
                return rastreamentoService.Get(id);
            }
            return BadRequest();
        }
        [HttpPost]
        public void Post([FromBody] Rastreamento rastreamentoModel)
        {
            if (ModelState.IsValid)
            {
                rastreamentoService.Post<RastreamentoValidator>(rastreamentoModel);
            }
        }
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Rastreamento rastreamentoModel)
        {
            if (id <= 0)
                NotFound();

            if (ModelState.IsValid)
            {
                Rastreamento rastreamento = rastreamentoService.Get(id);
                rastreamento.MinutosOcioso = rastreamentoModel.MinutosOcioso;
                rastreamento.TempoFinalOciosidade = rastreamentoModel.TempoFinalOciosidade;
                rastreamento.TempoIniciailOciosidade = rastreamentoModel.TempoIniciailOciosidade;
                rastreamento.PessoaId = rastreamentoModel.PessoaId;

                rastreamentoService.Put<RastreamentoValidator>(rastreamento);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            if (id <= 0)
                NotFound();

            rastreamentoService.Delete(id);
        }
    }
}

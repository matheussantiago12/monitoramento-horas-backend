using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers
{
    [Route("api/pessoa")]
    [ApiController]
    public class PessoaController : Controller
    {
        private readonly IService<Pessoa> pessoaService;
        public PessoaController(IService<Pessoa> _pessoaService)
        {
            this.pessoaService = _pessoaService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Pessoa>> GetAll()
        {
            return pessoaService.Get().ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Pessoa> GetById(long id)
        {
            if (ModelState.IsValid)
            {
                return pessoaService.Get(id);
            }
            return BadRequest();
        }
        [HttpPost]
        public void Post([FromBody] Pessoa pessoaModel)
        {
            if (ModelState.IsValid)
            {
                Pessoa insertedPessoa = pessoaService.Post<PessoaValidator>(pessoaModel);
            }
        }
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Pessoa pessoaModel)
        {
            if (id <= 0)
                NotFound();

            if (ModelState.IsValid)
            {
                Pessoa pessoa = pessoaService.Get(id);
                pessoa.Cargo = pessoaModel.Cargo;
                pessoa.HorasTrabalhoDiario = pessoaModel.HorasTrabalhoDiario;
                pessoa.NomeCompleto = pessoaModel.NomeCompleto;
                pessoa.TipoPessoaId = pessoaModel.TipoPessoaId;

                pessoaService.Put<PessoaValidator>(pessoa);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            if (id <= 0)
                NotFound();

            pessoaService.Delete(id);
        }
    }
}

using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Service.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers
{
    [Route("api/tipo-pessoa")]
    [ApiController]
    public class TipoPessoaController : Controller
    {
        private readonly IService<TipoPessoa> tipoPessoaService;
        public TipoPessoaController(IService<TipoPessoa> _tipoPessoaService)
        {
            this.tipoPessoaService = _tipoPessoaService;
        }
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<TipoPessoa>> GetAll()
        {
            return tipoPessoaService.Get().ToList();
        }
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<TipoPessoa> GetById(long id)
        {
            if (ModelState.IsValid)
            {
                return tipoPessoaService.Get(id);
            }
            return BadRequest();
        }
        [HttpPost]
        [Authorize]
        public void Post([FromBody] TipoPessoa tipoPessoaModel)
        {
            if (ModelState.IsValid)
            {
                tipoPessoaService.Post<TipoPessoaValidator>(tipoPessoaModel);
            }
        }
        [HttpPut("{id}")]
        [Authorize]
        public void Put(long id, [FromBody] TipoPessoa tipoPessoaModel)
        {
            if (id <= 0)
                NotFound();

            if (ModelState.IsValid)
            {
                TipoPessoa tipoPessoa = tipoPessoaService.Get(id);
                tipoPessoa.Descricao = tipoPessoaModel.Descricao;

                var LastUpdatedTipoPessoa = tipoPessoaService.Put<TipoPessoaValidator>(tipoPessoa);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(long id)
        {
            if (id <= 0)
                NotFound();

            tipoPessoaService.Delete(id);
        }
    }
}

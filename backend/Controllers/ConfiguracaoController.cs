using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers
{
    [Route("api/configuracao")]
    [ApiController]
    public class ConfiguracaoController : Controller
    {
        private readonly IService<Configuracao> configuracaoService;
        public ConfiguracaoController(IService<Configuracao> _configuracaoService)
        {
            this.configuracaoService = _configuracaoService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Configuracao>> GetAll()
        {
            return configuracaoService.Get().ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Configuracao> GetById(long id)
        {
            if (ModelState.IsValid)
            {
                return configuracaoService.Get(id);
            }
            return BadRequest();
        }
        [HttpPost]
        public void Post([FromBody] Configuracao configuracaoModel)
        {
            if (ModelState.IsValid)
            {
                configuracaoService.Post<ConfiguracaoValidator>(configuracaoModel);
            }
        }
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Configuracao configuracaoModel)
        {
            if (id <= 0)
                NotFound();

            if (ModelState.IsValid)
            {
                Configuracao configuracao = configuracaoService.Get(id);
                configuracao.PausaPeriodo = configuracaoModel.PausaPeriodo;
                configuracao.TempoLimiteOciosidade = configuracaoModel.TempoLimiteOciosidade;

                configuracaoService.Put<ConfiguracaoValidator>(configuracao);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            if (id <= 0)
                NotFound();

            configuracaoService.Delete(id);
        }
    }
}

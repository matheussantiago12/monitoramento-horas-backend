using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Service.Services;
using backend.Service.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers
{
    [Route("api/Rastreamento")]
    [ApiController]
    public class RastreamentoController : Controller
    {
        private readonly RastreamentoService _rastreamentoService;
        public RastreamentoController(RastreamentoService rastreamentoService)
        {
            _rastreamentoService = rastreamentoService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Rastreamento>> GetAll()
        {
            return _rastreamentoService.Get().ToList();
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Rastreamento> GetById(long id)
        {
            if (ModelState.IsValid)
            {
                return _rastreamentoService.Get(id);
            }
            return BadRequest();
        }

        [HttpPost]
        [Authorize]
        public void Post([FromBody] Rastreamento rastreamentoModel)
        {
            if (ModelState.IsValid)
            {
                _rastreamentoService.Post<RastreamentoValidator>(rastreamentoModel);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public void Put(long id, [FromBody] Rastreamento rastreamentoModel)
        {
            if (id <= 0)
                NotFound();

            if (ModelState.IsValid)
            {
                Rastreamento rastreamento = _rastreamentoService.Get(id);
                rastreamento.TempoFinalOciosidade = rastreamentoModel.TempoFinalOciosidade;
                rastreamento.TempoInicialOciosidade = rastreamentoModel.TempoInicialOciosidade;
                rastreamento.PessoaId = rastreamentoModel.PessoaId;

                _rastreamentoService.Put<RastreamentoValidator>(rastreamento);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(long id)
        {
            if (id <= 0)
                NotFound();

            _rastreamentoService.Delete(id);
        }

        [HttpGet("Dashboard")]
        public ActionResult<IEnumerable<Rastreamento>> GetRastreamentoPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            return _rastreamentoService.GetRastreamentoPorPeriodo(dataInicio, dataFim).ToList();
        }

        [HttpGet("Dashboard/PorSetor")]
        public ActionResult<IEnumerable<Rastreamento>> GetRastreamentoPorSetorPeriodo(int setorId, DateTime dataInicio, DateTime dataFim)
        {
            return _rastreamentoService.GetRastreamentoPorSetorPeriodo(dataInicio, dataFim, setorId).ToList();
        }

        [HttpGet("Dashboard/PorEquipe")]
        public ActionResult<IEnumerable<Rastreamento>> GetRastreamentoPorEquipePeriodo(int equipe, DateTime dataInicio, DateTime dataFim)
        {
            return _rastreamentoService.GetRastreamentoPorEquipePeriodo(dataInicio, dataFim, equipe).ToList();
        }

        [HttpGet("Dashboard/PorPessoa")]
        public ActionResult<IEnumerable<Rastreamento>> GetRastreamentoPorPessoaPeriodo(int pessoaId, DateTime dataInicio, DateTime dataFim)
        {
            return _rastreamentoService.GetRastreamentoPorPessoaPeriodo(dataInicio, dataFim, pessoaId).ToList();
        }
    }
}

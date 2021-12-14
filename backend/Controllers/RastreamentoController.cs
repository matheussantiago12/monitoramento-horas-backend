using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Dtos;
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
        public ActionResult<IEnumerable<RetornoRastreamentoPorPeriodoDto>> GetRastreamentoPorPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            var rastreamentos = _rastreamentoService.GetRastreamentoPorPeriodo(dataInicio, dataFim).ToList();
            var listaTempoOciosoPessoa = new List<TempoOciosoPessoaDto>();

            foreach (var rastreamento in rastreamentos)
            {
                listaTempoOciosoPessoa.Add(new TempoOciosoPessoaDto
                {
                    TempoOcioso = (rastreamento.TempoFinalOciosidade - rastreamento.TempoInicialOciosidade).TotalMinutes,
                    Pessoa = rastreamento.Pessoa
                });
            }

            var listaAgrupadaPorSetor = listaTempoOciosoPessoa.GroupBy(l => l.Pessoa.Equipe.SetorId).ToList();
            var listaFinal = new List<RetornoRastreamentoPorPeriodoDto>();
            double totalTempoOcioso;
            double totalPessoas;
            List<Pessoa> pessoasPercorridas = new List<Pessoa>();
            Setor setorAtual;

            foreach (var agrupamentoSetor in listaAgrupadaPorSetor)
            {
                totalTempoOcioso = 0;
                totalPessoas = 0;
                setorAtual = null;
                pessoasPercorridas.Clear();

                foreach (var pessoa in agrupamentoSetor)
                {
                    totalTempoOcioso += pessoa.TempoOcioso;
                    if (!pessoasPercorridas.Contains(pessoa.Pessoa))
                    {
                        totalPessoas++;
                        pessoasPercorridas.Add(pessoa.Pessoa);
                    }
                    setorAtual = pessoa.Pessoa.Equipe.Setor;
                }
                listaFinal.Add(new RetornoRastreamentoPorPeriodoDto 
                { 
                    MediaMinutosOciosos = totalTempoOcioso / totalPessoas,
                    Setor = setorAtual
                });
            }

            return Ok(listaFinal);
        }

        [HttpGet("Dashboard/PorSetor")]
        public ActionResult<IEnumerable<RetornoRastreamentoPorPeriodoEquipeDto>> GetRastreamentoPorSetorPeriodo(int setorId, DateTime dataInicio, DateTime dataFim)
        {
            var rastreamentos = _rastreamentoService.GetRastreamentoPorSetorPeriodo(dataInicio, dataFim, setorId).ToList();
            var listaTempoOciosoPessoa = new List<TempoOciosoPessoaDto>();

            foreach (var rastreamento in rastreamentos)
            {
                listaTempoOciosoPessoa.Add(new TempoOciosoPessoaDto
                {
                    TempoOcioso = (rastreamento.TempoFinalOciosidade - rastreamento.TempoInicialOciosidade).TotalMinutes,
                    Pessoa = rastreamento.Pessoa
                });
            }

            var listaAgrupadaPorEquipe = listaTempoOciosoPessoa.GroupBy(l => l.Pessoa.EquipeId).ToList();
            var listaFinal = new List<RetornoRastreamentoPorPeriodoEquipeDto>();
            double totalTempoOcioso;
            double totalPessoas;
            List<Pessoa> pessoasPercorridas = new List<Pessoa>();
            Equipe equipeAtual;

            foreach (var agrupamentoSetor in listaAgrupadaPorEquipe)
            {
                totalTempoOcioso = 0;
                totalPessoas = 0;
                equipeAtual = null;
                pessoasPercorridas.Clear();

                foreach (var pessoa in agrupamentoSetor)
                {
                    totalTempoOcioso += pessoa.TempoOcioso;
                    if (!pessoasPercorridas.Contains(pessoa.Pessoa))
                    {
                        totalPessoas++;
                        pessoasPercorridas.Add(pessoa.Pessoa);
                    }
                    equipeAtual = pessoa.Pessoa.Equipe;
                }
                listaFinal.Add(new RetornoRastreamentoPorPeriodoEquipeDto
                {
                    MediaMinutosOciosos = totalTempoOcioso / totalPessoas,
                    Equipe = equipeAtual
                });
            }

            return Ok(listaFinal);
        }

        [HttpGet("Dashboard/PorEquipe")]
        public ActionResult<IEnumerable<TempoOciosoPessoaDto>> GetRastreamentoPorEquipePeriodo(int equipeId, DateTime dataInicio, DateTime dataFim)
        {
            var rastreamentos = _rastreamentoService.GetRastreamentoPorEquipePeriodo(dataInicio, dataFim, equipeId).ToList();
            var listaTempoOciosoPessoa = new List<TempoOciosoPessoaDto>();

            foreach (var rastreamento in rastreamentos)
            {
                listaTempoOciosoPessoa.Add(new TempoOciosoPessoaDto
                {
                    TempoOcioso = (rastreamento.TempoFinalOciosidade - rastreamento.TempoInicialOciosidade).TotalMinutes,
                    Pessoa = rastreamento.Pessoa
                });
            }

            var listaAgrupadaPorPessoa = listaTempoOciosoPessoa.GroupBy(l => l.Pessoa.Id).ToList();
            var listaFinal = new List<TempoOciosoPessoaDto>();
            double soma;
            Pessoa pessoaAtual;

            foreach (var agrupamentoPessoa in listaAgrupadaPorPessoa)
            {
                soma = 0;
                pessoaAtual = null;
                foreach (var rastreamento in agrupamentoPessoa)
                {
                    soma += rastreamento.TempoOcioso;
                    pessoaAtual = rastreamento.Pessoa;
                }
                listaFinal.Add(new TempoOciosoPessoaDto
                {
                    TempoOcioso = soma,
                    Pessoa = pessoaAtual
                });
            }

            return Ok(listaFinal);
        }

        [HttpGet("Dashboard/PorPessoa")]
        public ActionResult<IEnumerable<Rastreamento>> GetRastreamentoPorPessoaPeriodo(int pessoaId, DateTime dataInicio, DateTime dataFim)
        {
            return _rastreamentoService.GetRastreamentoPorPessoaPeriodo(dataInicio, dataFim, pessoaId).ToList();
        }
    }
}

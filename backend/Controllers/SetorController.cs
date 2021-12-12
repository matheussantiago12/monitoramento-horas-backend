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
    [Route("api/setor")]
    [ApiController]
    public class SetorController : Controller
    {
        private readonly SetorService setorService;
        public SetorController(IService<Setor> _setorService)
        {
            this.setorService = (SetorService)_setorService;
        }
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Setor>> GetAll()
        {
            return setorService.Get().ToList();
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Setor>> GetAllLikeNome(string nome)
        {
            return setorService.GetAllLikeNome(nome).ToList();
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Setor> GetById(long id)
        {
            if (ModelState.IsValid)
            {
                return setorService.Get(id);
            }
            return BadRequest();
        }
        [HttpPost]
        [Authorize]
        public void Post([FromBody] Setor setorModel)
        {
            if (ModelState.IsValid)
            {
                Setor insertedSupplier = setorService.Post<SetorValidator>(setorModel);
            }
        }
        [HttpPut("{id}")]
        [Authorize]
        public void Put(long id, [FromBody] Setor setorModel)
        {
            if (id <= 0)
                NotFound();

            if (ModelState.IsValid)
            {
                Setor setor = setorService.Get(id);
                setor.Descricao = setorModel.Descricao;

                setorService.Put<SetorValidator>(setor);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(long id)
        {
            if (id <= 0)
                NotFound();

            setorService.Delete(id);
        }
    }
}

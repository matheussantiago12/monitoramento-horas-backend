using backend.Domain.Entites;
using backend.Domain.Interfaces;
using backend.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace backend.Controllers
{
    [Route("api/setor")]
    [ApiController]
    public class SetorController : Controller
    {
        private readonly IService<Setor> setorService;
        public SetorController(IService<Setor> _setorService)
        {
            this.setorService = _setorService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Setor>> GetAll()
        {
            return setorService.Get().ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Setor> GetById(long id)
        {
            if (ModelState.IsValid)
            {
                return setorService.Get(id);
            }
            return BadRequest();
        }
        [HttpPost]
        public void Post([FromBody] Setor setorModel)
        {
            if (ModelState.IsValid)
            {
                Setor insertedSupplier = setorService.Post<SetorValidator>(setorModel);
            }
        }
        [HttpPut("{id}")]
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
        public void Delete(long id)
        {
            if (id <= 0)
                NotFound();

            setorService.Delete(id);
        }
    }
}

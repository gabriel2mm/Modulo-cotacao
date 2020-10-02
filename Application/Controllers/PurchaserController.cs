using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    /// <summary>
    /// Simula a entrada via API de uma proposta representado no sistema pela entidade
    ///Purchaser
    /// </summary>
    [ApiController]
    [Route("api/[controller]s")]
    public class PurchaserController : ControllerBase
    {
        private readonly IRepository<Purchaser> _repository;
        public PurchaserController(IRepository<Purchaser> repository)
        {
            _repository = repository;
        }

        // GET: api/purchasers
        [HttpGet]
        public IEnumerable<Purchaser> Get()
        {
            return _repository.GetAll().ToList();
        }

        // GET api/purchasers/5
        [HttpGet("{id}")]
        public Purchaser Get(Guid id)
        {
            return _repository.Find(id);
        }

        // POST api/purchasers
        [HttpPost]
        public IActionResult Post([FromBody] Purchaser purchaser)
        {
            _repository.Add(purchaser);
            _repository.SaveAll();

            return Ok();

        }

        // PUT api/purchasers/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Purchaser value)
        {
           Purchaser purchaser = _repository.Find(id);
            if (purchaser != null)
            {
                purchaser.Copy(value);
                _repository.Update(purchaser);
                _repository.SaveAll();
            }
        }

        // DELETE api/purchasers/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _repository.Delete((p => id.Equals(p.Id)));
        }
    }
}

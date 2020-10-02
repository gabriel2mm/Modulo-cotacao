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
    /// Price
    /// </summary>
    [ApiController]
    [Route("api/[controller]s")]
    public class PriceController : ControllerBase
    {
        private readonly IRepository<Price> _repository;
        public PriceController(IRepository<Price> repository)
        {
            _repository = repository;
        }

        // GET: api/prices
        [HttpGet]
        public IEnumerable<Price> Get()
        {
            return _repository.GetAll().ToList();
        }

        // GET api/prices/5
        [HttpGet("{id}")]
        public Price Get(Guid id)
        {
            return _repository.Find(id);
        }

        // POST api/prices
        [HttpPost]
        public IActionResult Post([FromBody] Price price)
        {
            _repository.Add(price);
            _repository.SaveAll();

            return Ok();

        }

        // PUT api/prices/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Price value)
        {
            Price price = _repository.Find(id);
            if (price != null)
            {
                price.Copy(value);
                _repository.Update(price);
                _repository.SaveAll();
            }
        }

        // DELETE api/prices/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _repository.Delete((p => id.Equals(p.Id)));
        }
    }
}

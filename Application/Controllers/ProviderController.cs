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
    /// Provider
    /// </summary>
    [ApiController]
    [Route("api/[controller]s")]
    public class ProviderController : ControllerBase
    {
        private readonly IRepository<Provider> _repository;
        public ProviderController(IRepository<Provider> repository)
        {
            _repository = repository;
        }

        // GET: api/providers
        [HttpGet]
        public IEnumerable<Provider> Get()
        {
            return _repository.GetAll().ToList();
        }

        // GET api/providers/5
        [HttpGet("{id}")]
        public Provider Get(Guid id)
        {
            return _repository.Find(id);
        }

        // POST api/providers
        [HttpPost]
        public IActionResult Post([FromBody] Provider provider)
        {
            _repository.Add(provider);
            _repository.SaveAll();

            return Ok();

        }

        // PUT api/providers/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Provider value)
        {
            Provider provider = _repository.Find(id);
            if (provider != null)
            {
                provider.Copy(value);
                _repository.Update(provider);
                _repository.SaveAll();
            }
        }

        // DELETE api/providers/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _repository.Delete((p => id.Equals(p.Id)));
        }
    }
}

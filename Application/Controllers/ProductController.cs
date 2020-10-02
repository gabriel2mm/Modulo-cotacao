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
    /// Product
    /// </summary>
    [ApiController]
    [Route("api/[controller]s")]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _repository;
        public ProductController(IRepository<Product> repository)
        {
            _repository = repository;
        }

        // GET: api/products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _repository.GetAll().ToList();
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public Product Get(Guid id)
        {
            return _repository.Find(id);
        }

        // POST api/products
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _repository.Add(product);
            _repository.SaveAll();

            return Ok();
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Product value)
        {
            Product product = _repository.Find(id);
            if (product != null)
            {
                product.Copy(value);
                _repository.Update(product);
                _repository.SaveAll();
            }
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _repository.Delete((p => id.Equals(p.Id)));
        }
    }
}

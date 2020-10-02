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
    /// ProductProvider
    /// </summary>
    [ApiController]
    [Route("api/[controller]s")]
    public class ProductProviderController : ControllerBase
    {
        private readonly IRepository<ProductProvider> _repository;
        public ProductProviderController(IRepository<ProductProvider> repository)
        {
            _repository = repository;
        }

        // GET: api/productProviders
        [HttpGet]
        public IEnumerable<ProductProvider> Get()
        {
            return _repository.GetAll().ToList();
        }

        // GET api/productProviders/5
        [HttpGet("{id}")]
        public ProductProvider Get(Guid id)
        {
            return _repository.Find(id);
        }

        // POST api/productProviders
        [HttpPost]
        public IActionResult Post([FromBody] ProductProvider productProvider)
        {
            _repository.Add(productProvider);
            _repository.SaveAll();

            return Ok();

        }

        // PUT api/productProviders/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] ProductProvider value)
        {
            ProductProvider productProvider = _repository.Find(id);
            if (productProvider != null)
            {
                productProvider.Copy(value);
                _repository.Update(productProvider);
                _repository.SaveAll();
            }
        }

        // DELETE api/productProviders/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _repository.Delete((p => id.Equals(p.ProductId) || id.Equals(p.ProviderId)));
        }
    }
}

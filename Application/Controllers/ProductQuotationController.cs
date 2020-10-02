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
    /// ProductQuotation
    /// </summary>
    [ApiController]
    [Route("api/[controller]s")]
    public class ProductQuotationController : ControllerBase
    {
        private readonly IRepository<ProductQuotation> _repository;
        public ProductQuotationController(IRepository<ProductQuotation> repository)
        {
            _repository = repository;
        }

        // GET: api/productQuotations
        [HttpGet]
        public IEnumerable<ProductQuotation> Get()
        {
            return _repository.GetAll().ToList();
        }

        // GET api/productQuotations/5
        [HttpGet("{id}")]
        public ProductQuotation Get(Guid id)
        {
            return _repository.Find(id);
        }

        // POST api/productQuotations
        [HttpPost]
        public IActionResult Post([FromBody] ProductQuotation productQuotation)
        {
            _repository.Add(productQuotation);
            _repository.SaveAll();

            return Ok();

        }

        // PUT api/productQuotations/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] ProductQuotation value)
        {
            ProductQuotation productQuotation = _repository.Find(id);
            if (productQuotation != null)
            {
                productQuotation.Copy(value);
                _repository.Update(productQuotation);
                _repository.SaveAll();
            }
        }

        // DELETE api/productQuotations/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _repository.Delete((p => id.Equals(p.Id)));
        }
    }
}

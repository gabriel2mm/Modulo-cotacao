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
    /// Proporsal
    /// </summary>
    [ApiController]
    [Route("api/[controller]s")]
    public class ProporsalController : ControllerBase
    {
        private readonly IRepository<Proporsal> _repository;
        private readonly IRepository<SupplyOrder> _supplyRepository;
        public ProporsalController(IRepository<Proporsal> repository, IRepository<SupplyOrder> supplyRepository)
        {
            _repository = repository;
            _supplyRepository = supplyRepository;
        }

        // GET: api/proporsals
        [HttpGet]
        public IEnumerable<Proporsal> Get()
        {
            return _repository.GetAll().ToList();
        }

        // GET api/proporsals/5
        [HttpGet("{id}")]
        public Proporsal Get(Guid id)
        {
            return _repository.Find(id);
        }

        // POST api/proporsals
        [HttpPost]
        public IActionResult Post([FromBody] Proporsal proporsal)
        {
            if (proporsal?.Prices?.Count >= 3)
            {
                _repository.Add(proporsal);
                _repository.SaveAll();

                //Pega melhor cotação e efetua compra
                Price price = MakePurchaseService.ProcessProposal(proporsal);
                SupplyOrder supplyOrder = MakePurchaseService.CreateSupplyOrder(price);

                //Ordem de compra sem aprovação (para aprovar é necessário uma ação manual)
                _supplyRepository.Add(supplyOrder);
                _supplyRepository.SaveAll();

                return Ok();
            }

            return BadRequest(new { error = "Você não atende o minimo de cotações" });

        }

        // PUT api/proporsals/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Proporsal value)
        {
            Proporsal proporsal = _repository.Find(id);
            if (proporsal != null)
            {
                proporsal.Copy(value);
                _repository.Update(proporsal);
                _repository.SaveAll();
            }
        }

        // DELETE api/proporsals/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _repository.Delete((p => id.Equals(p.Id)));
        }
    }
}

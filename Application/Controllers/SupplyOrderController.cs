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
    /// SupplyOrder
    /// </summary>
    [ApiController]
    [Route("api/[controller]s")]
    public class SupplyOrderController : ControllerBase
    {
        private readonly IRepository<SupplyOrder> _repository;
        public SupplyOrderController(IRepository<SupplyOrder> repository)
        {
            _repository = repository;
        }

        // GET: api/supplyOrders
        [HttpGet]
        public IEnumerable<SupplyOrder> Get()
        {
            return _repository.GetAll().ToList();
        }

        // GET api/supplyOrders/5
        [HttpGet("{id}")]
        public SupplyOrder Get(Guid id)
        {
            return _repository.Find(id);
        }

        // POST api/supplyOrders
        [HttpPost]
        public IActionResult Post([FromBody] SupplyOrder supplyOrder)
        {
            return BadRequest(new { error = "Você não atende o minimo de cotações" });
        }

        // PUT api/supplyOrders/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] SupplyOrder value)
        {
            SupplyOrder supplyOrder = _repository.Find(id);
            if (supplyOrder != null)
            {
                supplyOrder.Copy(value);
                _repository.Update(supplyOrder);
                _repository.SaveAll();
            }
        }

        // DELETE api/supplyOrders/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _repository.Delete((p => id.Equals(p.Id)));
        }

        // PUT api/supplyOrders/approve/5
        [HttpPut("{id}")]
        public void Approve(Guid id)
        {
            SupplyOrder order = _repository.Find(id);
            if (order != null)
            {
                order.Authorization = true;
                _repository.Update(order);
                _repository.SaveAll();
                MakePurchaseService.SendProductsToStock(order);
            }
        }
    }
}

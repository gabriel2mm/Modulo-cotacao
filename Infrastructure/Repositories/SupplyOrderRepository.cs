using Domain.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class SupplyOrderRepository : Repository<SupplyOrder>
    {
        protected readonly new Context _context;
        public SupplyOrderRepository(Context context) : base(context)
        {
            _context = context;
        }

        public override IQueryable<SupplyOrder> GetAll()
        {
            return base.GetAll()
                .Include(p => p.SelectedPrice);
        }

        public override SupplyOrder Find(params object[] key)
        {
            SupplyOrder supplyOrder = base.Find(key);
            if (supplyOrder != null)
            {
                _context.Entry(supplyOrder)
                    .Reference<Price>(p => p.SelectedPrice).Load();
            }
            return supplyOrder;
        }

        public override void Update(SupplyOrder obj)
        {
            _context.Entry(obj.SelectedPrice).State = EntityState.Modified;
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}

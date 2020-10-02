using Domain.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class PriceRepository : Repository<Price>
    {
        protected readonly new Context _context;
        public PriceRepository(Context context) : base(context)
        {
            _context = context;
        }

        public override IQueryable<Price> GetAll()
        {
            return base.GetAll()
                .Include(p => p.Purchaser)
                .Include(p => p.Provider)
                .Include(p => p.Proporsal)
                .Include(p => p.ProductQuotations);
        }

        public override Price Find(params object[] key)
        {
            Price price = base.Find(key);
            if (price != null)
            {
                _context.Entry(price)
                    .Collection<ProductQuotation>(p => p.ProductQuotations).Load();
                _context.Entry(price)
                    .Reference<Proporsal>(p => p.Proporsal).Load();
                _context.Entry(price)
                    .Reference<Provider>(p => p.Provider).Load();
                _context.Entry(price)
                    .Reference<Purchaser>(p => p.Purchaser).Load();
            }
            return price;
        }

        public override void Update(Price obj)
        {
            _context.Entry(obj.Purchaser).State = EntityState.Modified;
            _context.Entry(obj.Provider).State = EntityState.Modified;
            _context.Entry(obj.Proporsal).State = EntityState.Modified;
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}

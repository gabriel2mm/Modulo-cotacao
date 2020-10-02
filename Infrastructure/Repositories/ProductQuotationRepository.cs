using Domain.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ProductQuotationRepository : Repository<ProductQuotation>
    {
        protected readonly new Context _context;
        public ProductQuotationRepository(Context context) : base(context)
        {
            _context = context;
        }

        public override IQueryable<ProductQuotation> GetAll()
        {
            return base.GetAll()
                .Include(p => p.Price)
                .Include(p => p.Product);
        }

        public override ProductQuotation Find(params object[] key)
        {
            ProductQuotation productQuotation = base.Find(key);
            if (productQuotation != null)
            {
                _context.Entry(productQuotation).Reference<Price>(p => p.Price).Load();
                _context.Entry(productQuotation).Reference<Product>(p => p.Product).Load();
            }
            return productQuotation;
        }

        public override void Update(ProductQuotation obj)
        {
            _context.Entry(obj.Price).State = EntityState.Modified;
            _context.Entry(obj.Product).State = EntityState.Modified;
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}

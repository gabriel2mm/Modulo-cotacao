using Domain.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        protected readonly new Context _context;
        public ProductRepository(Context context) : base(context)
        {
            _context = context;
        }

        public override IQueryable<Product> GetAll()
        {
            return base.GetAll()
                .Include(p => p.Providers);
        }

        public override Product Find(params object[] key)
        {
            Product product = base.Find(key);
            if (product != null)
            {
                _context.Entry(product).Collection<ProductProvider>(p => p.Providers).Load();
            }
            return product;
        }

        public override void Update(Product obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}

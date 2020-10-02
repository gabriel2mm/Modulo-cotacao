using Domain.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ProductProviderRepository : Repository<ProductProvider>
    {
        protected readonly new Context _context;
        public ProductProviderRepository(Context context) : base(context)
        {
            _context = context;
        }

        public override IQueryable<ProductProvider> GetAll()
        {
            return base.GetAll()
                .Include(p => p.Product)
                .Include(p => p.Provider);
        }

        public override ProductProvider Find(params object[] key)
        {
            ProductProvider productProvider = base.Find(key);
            if (productProvider != null)
            {
                _context.Entry(productProvider)
                    .Reference<Product>(p => p.Product).Load();
                _context.Entry(productProvider)
                    .Reference<Provider>(p => p.Provider).Load();
            }
            return productProvider;
        }

        public override void Update(ProductProvider obj)
        {
            _context.Entry(obj.Product).State = EntityState.Modified;
            _context.Entry(obj.Provider).State = EntityState.Modified;
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}

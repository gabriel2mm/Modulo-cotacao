using Domain.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ProviderRepository : Repository<Provider>
    {
        protected readonly new Context _context;
        public ProviderRepository(Context context) : base(context)
        {
            _context = context;
        }

        public override IQueryable<Provider> GetAll()
        {
            return base.GetAll()
                .Include(p => p.Products);
        }

        public override Provider Find(params object[] key)
        {
            Provider provider = base.Find(key);
            if (provider != null)
            {
                _context.Entry(provider).Collection<ProductProvider>(p => p.Products).Load();
            }
            return provider;
        }

        public override void Update(Provider obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}

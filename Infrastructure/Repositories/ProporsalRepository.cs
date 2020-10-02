using Domain.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ProporsalRepository : Repository<Proporsal>
    {
        protected readonly new Context _context;
        public ProporsalRepository(Context context) : base(context)
        {
            _context = context;
        }

        public override IQueryable<Proporsal> GetAll()
        {
            return base.GetAll()
                .Include(p => p.Prices);
        }

        public override Proporsal Find(params object[] key)
        {
            Proporsal proporsal = base.Find(key);
            if (proporsal != null)
            {
                _context.Entry(proporsal).Collection<Price>(p => p.Prices).Load();
            }
            return proporsal;
        }

        public override void Update(Proporsal obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}

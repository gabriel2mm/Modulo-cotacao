using Domain.Models;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class PurchaserRepository : Repository<Purchaser>
    {
        protected readonly new Context _context;
        public PurchaserRepository(Context context) : base(context)
        {
            _context = context;
        }
    }
}

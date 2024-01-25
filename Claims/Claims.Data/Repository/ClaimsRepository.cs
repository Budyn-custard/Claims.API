using Claims.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Data.Repository
{
    public class ClaimsRepository : IClaimsRepository
    {
        private readonly ClaimsDbContext _context;
        public ClaimsRepository(ClaimsDbContext context)
        {
            _context = context;
        }
        public Task<Claim> Get(string ucr)
        {
            return _context.Claims.FirstOrDefaultAsync(p=>p.UCR == ucr);
        }

        public Task<List<Claim>> GetForCompany(Expression<Func<Claim, bool>> predicate)
        {
            return _context.Claims.Where(predicate).ToListAsync();
        }

        public Task<int> Update(Claim claim)
        {
            _context.Claims.Update(claim);
            return _context.SaveChangesAsync();
        }
    }
}

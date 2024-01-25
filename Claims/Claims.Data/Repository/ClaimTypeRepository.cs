using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Data.Repository
{
    public class ClaimTypeRepository : IClaimTypeRepository
    {
        private readonly ClaimsDbContext _context;
        public ClaimTypeRepository(ClaimsDbContext context)
        {
            _context = context;
        }
        public Task<bool> Exists(int id)
        {
            return _context.ClaimTypes.AnyAsync(x => x.Id == id);
        }
    }
}

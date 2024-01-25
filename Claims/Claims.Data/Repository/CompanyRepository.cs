using Claims.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Data.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ClaimsDbContext _context;

        public CompanyRepository(ClaimsDbContext context)
        {
            _context = context;
        }
        public Task<Company> GetCompany(int id)
        {
            return _context.Companies.Where(c => c.Id == id).Include(c => c.Claims).FirstOrDefaultAsync();
        }
    }
}

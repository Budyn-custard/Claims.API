using Claims.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Data.Repository
{
    public interface IClaimsRepository
    {
        Task<List<Claim>> GetForCompany(Expression<Func<Claim, bool>> predicate);
        Task<Claim> Get(string ucr);
        Task<int> Update(Claim claim);
    }
}

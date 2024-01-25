using Claims.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Data.Repository
{
    public interface ICompanyRepository
    {
        Task<Company> GetCompany(int id);
    }
}

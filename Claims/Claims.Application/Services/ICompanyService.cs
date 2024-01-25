using Claims.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Application.Services
{
    public interface ICompanyService
    {
        Task<CompanyViewModel> GetByIdAsync(int id);
    }
}

using Claims.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Application.Services
{
    public interface IClaimsService
    {
        Task<ClaimViewModel> Get(string ucr);
        Task<List<ClaimViewModel>> GetForCompany(int  companyId);
        Task<ClaimViewModel> Update(ClaimViewModelPut mode, string ucr);
    }
}

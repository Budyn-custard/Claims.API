using AutoMapper;
using Claims.Application.Helpers;
using Claims.Data.Repository;
using Claims.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<CompanyViewModel> GetByIdAsync(int id)
        {
            var company = await _companyRepository.GetCompany(id);
            if (company == null)
                throw new BusinessException((int)HttpStatusCode.NotFound, "Not Found");

            return _mapper.Map<CompanyViewModel>(company);
        }
    }
}

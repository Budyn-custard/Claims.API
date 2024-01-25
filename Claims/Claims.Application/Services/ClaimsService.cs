using AutoMapper;
using Claims.Application.Helpers;
using Claims.Data.Entities;
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
    public class ClaimsService : IClaimsService
    {
        private readonly IClaimsRepository _claimsRepository;
        private readonly IMapper _mapper;
        private readonly IClaimTypeRepository _claimTypeRepository;

        public ClaimsService(IClaimsRepository claimsRepository, IMapper mapper, IClaimTypeRepository claimTypeRepository)
        {
            _claimsRepository = claimsRepository;
            _mapper = mapper;
            _claimTypeRepository = claimTypeRepository;

        }

        public async Task<ClaimViewModel> Get(string ucr)
        {
            var claim = await _claimsRepository.Get(ucr);
            if(claim == null)
                throw new BusinessException((int)HttpStatusCode.NotFound, new ErrorResponse("Not found."));

            return _mapper.Map<ClaimViewModel>(claim);
        }

        public async Task<List<ClaimViewModel>> GetForCompany(int companyId)
        {
            return _mapper.Map<List<ClaimViewModel>>(await _claimsRepository.GetForCompany(p=>p.CompanyId == companyId)) ?? new List<ClaimViewModel>();
        }

        public async Task<ClaimViewModel> Update(ClaimViewModelPut model, string ucr)
        {
            var claim = await _claimsRepository.Get(ucr);
            if (claim == null)
                throw new BusinessException((int)HttpStatusCode.NotFound, new ErrorResponse("Not found."));

            if(claim.ClaimTypeId != model.ClaimTypeId && !await _claimTypeRepository.Exists(model.ClaimTypeId))
                throw new BusinessException((int)HttpStatusCode.BadRequest, new ErrorResponse("ClaimTypeId does not exist."));

            claim = _mapper.Map(model, claim);
            var update = await _claimsRepository.Update(claim);
            if(update == 0)
                throw new BusinessException((int)HttpStatusCode.InternalServerError, new ErrorResponse("Something went wrong."));

            return _mapper.Map<ClaimViewModel>(claim);
        }
    }
}

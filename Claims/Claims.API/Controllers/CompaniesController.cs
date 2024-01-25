using Claims.Application.Services;
using Claims.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Claims.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IClaimsService _claimsService;

        public CompaniesController(ICompanyService companyService, IClaimsService claimService)
        {
            _companyService = companyService;
            _claimsService = claimService;
        }
        [HttpGet("{id}")]
        [Produces<CompanyViewModel>]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _companyService.GetByIdAsync(id));
        }

        [HttpGet("{id}/claims")]
        [Produces<List<ClaimViewModel>>]
        public async Task<IActionResult> GetClaims(int id)
        {
            return Ok(await _claimsService.GetForCompany(id));
        }

    }
}

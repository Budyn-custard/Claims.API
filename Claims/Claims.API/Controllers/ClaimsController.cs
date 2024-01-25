using Claims.Application.Services;
using Claims.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Claims.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimsService _claimsService;

        public ClaimsController(IClaimsService claimsService)
        {
            _claimsService = claimsService;
        }

        [HttpGet("{ucr}")]
        [Produces<ClaimViewModel>]
        public async Task<IActionResult> Get(string ucr)
        {
            return Ok(await _claimsService.Get(ucr));
        }

        [HttpPut("{ucr}")]
        [Produces<ClaimViewModel>]
        public async Task<IActionResult> Put(ClaimViewModelPut model, string ucr)
        {
            return Ok(await _claimsService.Update(model, ucr));
        }
    }
}

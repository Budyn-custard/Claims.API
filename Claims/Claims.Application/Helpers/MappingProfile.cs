using AutoMapper;
using Claims.Data.Entities;
using Claims.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Claims.Application.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Claim, ClaimViewModel>().ReverseMap();
            CreateMap<Claim, ClaimViewModelPut>().ReverseMap();
            CreateMap<ClaimType, ClaimTypeViewModel>().ReverseMap();
            CreateMap<Company, CompanyViewModel>().ForMember(dest => dest.HasActiveClaims, opt => opt.MapFrom(src => src.Claims.Any(claim => !claim.Closed)));
        }
    }
}

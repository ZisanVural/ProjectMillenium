using AutoMapper;
using ProjectMillenium.Core.Entities;
using ProjectMillenium.Web.Models;

namespace ProjectMillenium.Web.Mapping
{
    public class ClaimProfile:Profile
    {
        public ClaimProfile()
        {
            CreateMap<Claim, ClaimViewModel>()
        .ForMember(dest =>
           dest.Name,
           opt => opt.MapFrom(src => src.Name))
        .ForMember(dest =>
           dest.Description,
           opt => opt.MapFrom(src => src.Description))
       .ReverseMap();
        }
    }
}

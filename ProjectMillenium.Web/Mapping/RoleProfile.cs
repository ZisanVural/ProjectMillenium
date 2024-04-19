using AutoMapper;
using ProjectMillenium.Core.Entities;
using ProjectMillenium.Core.Entity;
using ProjectMillenium.Web.Models;

namespace ProjectMillenium.Web.Mapping
{
    public class RoleProfile:Profile

    {
        public RoleProfile()
        {
            CreateMap<Role, RoleViewModel>()
        .ForMember(dest =>
           dest.Name,
           opt => opt.MapFrom(src => src.Name))
        .ForMember(dest =>
           dest.Description,
           opt => opt.MapFrom(src => src.Description))
        .ForMember(dest =>
           dest.IsActive,
           opt => opt.MapFrom(src => src.IsActive))
        
       .ReverseMap();
        }
    }
}

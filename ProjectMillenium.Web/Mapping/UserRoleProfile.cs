using AutoMapper;
using ProjectMillenium.Core.Entities;
using ProjectMillenium.Core.Entity;
using ProjectMillenium.Web.Models;

namespace ProjectMillenium.Web.Mapping
{
    public class UserRoleProfile : Profile
    {

        public UserRoleProfile()
        {
            CreateMap<UserRole, UserRoleViewModel>()
     
    
       .ReverseMap();
        }
    }
}

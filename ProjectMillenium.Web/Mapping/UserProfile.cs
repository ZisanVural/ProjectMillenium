using AutoMapper;
using ProjectMillenium.Core.Entity;
using ProjectMillenium.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMillenium.Core.Mapping
{

    public class UserProfile:Profile //automappingte kullanılan sınıftır profile

    {
        public UserProfile() 
        {
            CreateMap<User, UserViewModel>()
        .ForMember(dest =>
           dest.Name,
           opt => opt.MapFrom(src => src.Name))
       .ForMember(dest =>
           dest.Username,
           opt => opt.MapFrom(src => src.Username))
       .ForMember(dest =>
           dest.Lastname,
           opt => opt.MapFrom(src => src.Lastname))
       .ForMember(dest =>
           dest.Email,
           opt => opt.MapFrom(src => src.Email))
       .ForMember(dest =>
           dest.Password,
           opt => opt.MapFrom(src => src.Password))
       .ReverseMap();
        }
    }

  
}

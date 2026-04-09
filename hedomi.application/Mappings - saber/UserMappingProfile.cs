using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hedomi.domain;
using hedomi.application.DTOs.UserDTOs;

namespace hedomi.application.Mappings___saber
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<UserDTO, User>();
            CreateMap<CreateUserDTO, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
             CreateMap<UpdateUserDTO, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }

    }   
}
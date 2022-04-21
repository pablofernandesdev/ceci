using AutoMapper;
using Ceci.Domain.DTO.Auth;
using Ceci.Domain.DTO.Role;
using Ceci.Domain.DTO.User;
using Ceci.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceci.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User
            CreateMap<User, UserAddDTO>().ReverseMap();

            CreateMap<User, UserSelfRegistrationDTO>().ReverseMap();

            CreateMap<User, UserImportDTO>().ReverseMap();

            CreateMap<User, UserResultDTO>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();

            CreateMap<User, UserUpdateDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<User, UserUpdateRoleDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<User, UserLoggedUpdateDTO>().ReverseMap();
            #endregion

            #region Auth
            CreateMap<User, AuthResultDTO>()
              .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.Name))
              .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Email))
              .ReverseMap();

            CreateMap<RefreshToken, AuthResultDTO>()
              .ForMember(dest => dest.RefreshToken, opt => opt.MapFrom(src => src.Token))
              .ReverseMap();
            #endregion

            #region Role
            CreateMap<Role, RoleAddDTO>().ReverseMap();

            CreateMap<Role, RoleResultDTO>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<Role, RoleUpdateDTO>()
                 .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id))
                 .ReverseMap();

            CreateMap<Role, RoleUpdateDTO>().ReverseMap();
            #endregion
        }
    }
}

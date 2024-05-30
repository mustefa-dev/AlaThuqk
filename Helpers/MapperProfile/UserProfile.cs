using AlaThuqk.DATA.DTOs;
using AlaThuqk.DATA.DTOs.User;
using AlaThuqk.Entities;
using AutoMapper;
using OneSignalApi.Model;

namespace AlaThuqk.Helpers.MapperProfile;

public class UserProfile: Profile{
      public UserProfile(){
            CreateMap<AppUser, UserDto>();
            CreateMap<AppUser, TokenDTO>();
            CreateMap<RegisterForm, AppUser>()
                  .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<UserForm, AppUser>();
            CreateMap<RegisterForm, App>()
                  .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

      }
}
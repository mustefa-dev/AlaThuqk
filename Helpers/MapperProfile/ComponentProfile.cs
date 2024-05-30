using AlaThuqk.DATA.DTOs;
using AlaThuqk.DATA.DTOs.Component;
using AlaThuqk.Entities;
using AutoMapper;

namespace AlaThuqk.Helpers.MapperProfile;

public class ComponentProfile: Profile{
    public ComponentProfile(){
        CreateMap<ComponentForm, Component>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<ComponentUpdate, Component>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<Component, ComponentDto>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
    
}
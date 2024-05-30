using AlaThuqk.DATA.DTOs.Color;
using AlaThuqk.Entities;
using AutoMapper;

namespace AlaThuqk.Helpers.MapperProfile;

public class ColorProfile: Profile{
    public ColorProfile(){
        CreateMap<Color, ColorDto>();
        CreateMap<ColorForm, Color>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<ColorUpdate, Color>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
    
}
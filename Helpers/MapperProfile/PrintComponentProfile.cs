using AlaThuqk.DATA.DTOs;
using AlaThuqk.DATA.DTOs.PrintComponent;
using AlaThuqk.Entities;
using AutoMapper;

namespace AlaThuqk.Helpers.MapperProfile;

public class PrintComponentProfile: Profile{
    public PrintComponentProfile(){
        CreateMap<PrintComponent, PrintComponentDto>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<PrintComponentForm, Entities.PrintComponent>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<PrintComponentUpdate, Entities.PrintComponent>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
    
    
}
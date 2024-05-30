using AlaThuqk.Entities;
using AutoMapper;
using Gaz_BackEnd.DATA.DTOs.Governorates;

namespace AlaThuqk.DATA.DTOs;

public class GovProfile: Profile{
    public  GovProfile(){
        CreateMap<GovernorateForm, Governorate>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<GovernorateForm, Governorate>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<Governorate, GovernoratesDTO>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
    
}
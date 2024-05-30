using AlaThuqk.DATA.DTOs.Size;
using AlaThuqk.Entities;
using AutoMapper;

namespace AlaThuqk.Helpers.MapperProfile;

public class SizeProfile : Profile{
    public SizeProfile() {
        CreateMap<SizeForm, Size>();
        CreateMap<SizeUpdate, Size>();
        CreateMap<Size, SizeDto>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
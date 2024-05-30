using AlaThuqk.DATA.DTOs;
using AlaThuqk.DATA.DTOs.Template;
using AlaThuqk.Entities;
using AutoMapper;

namespace AlaThuqk.Helpers.MapperProfile;

public class TemplateProfile : Profile{
    public TemplateProfile() {
        CreateMap<Template, TemplateDto>()
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src =>
                    src.Sizes == null
                        ? 0
                        : src.Sizes.Select(size =>
                            size.Colors == null ? 0 : size.Colors.Select(c => c.Quantity).Sum()
                        ).Sum()
                )
            )
            .ForMember(dest => dest.Components, opt => opt.MapFrom(src => src.Components))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<TemplateForm, Template>()
            .ForMember(dest => dest.Sizes, opt => opt.MapFrom(src => src.Sizes))
            .ForMember(dest => dest.Components, opt => opt.MapFrom(src => src.Components));
        CreateMap<TemplateUpdate, Template>();
    }
}
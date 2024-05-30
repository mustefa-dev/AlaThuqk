using AlaThuqk.DATA.DTOs;
using AlaThuqk.DATA.DTOs.Category;
using AlaThuqk.Entities;
using AutoMapper;

namespace AlaThuqk.Helpers.MapperProfile;

public class CategoryProfile : Profile{
    public CategoryProfile() {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryForm, Category>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<CategoryUpdate, Category>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

    }
}
using AlaThuqk.DATA.DTOs;
using AlaThuqk.DATA.DTOs.Product;
using AlaThuqk.Entities;
using AutoMapper;

namespace AlaThuqk.Helpers.MapperProfile;

public class ProductProfile : Profile{
    private readonly string baseUrl;


    public ProductProfile() {
        baseUrl = "http://192.168.1.48:5051/";

        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Quantity,
                opt => opt.MapFrom(x => x.Sizes.Sum(size => size.Colors.Sum(color => color.Quantity))))
            .ForMember(dist => dist.Likes, opt => opt.MapFrom(x => x.Likes))
            .ForMember(dist => dist.IsLiked, opt => opt.MapFrom(x => x.UserLikes.Any()
                ? x.UserLikes.Any(userLike => userLike.UserId == x.UserLikes.FirstOrDefault().UserId)
                : false
            ))
            .ForMember(dist => dist.CategoryName, opt => opt.MapFrom(x => x.Category.Name))
            .ForMember(dist => dist.CategoryId, opt => opt.MapFrom(x => x.Category.Id))
            .ForMember(dist => dist.Images, opt => opt.MapFrom(x =>
                x.Images.Select(image => baseUrl + image).ToArray()
            ));

        CreateMap<ProductForm, Product>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<ProductUpdate, Product>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<ProductForm, Product>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
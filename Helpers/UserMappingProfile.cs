using AlaThuqk
.DATA.DTOs;
using AlaThuqk.DATA.DTOs.Category;
using AlaThuqk.DATA.DTOs.Color;
using AlaThuqk.DATA.DTOs.Order;
using AlaThuqk.DATA.DTOs.OrderItem;
using AlaThuqk.DATA.DTOs.PrintComponent;
using AlaThuqk.DATA.DTOs.Size;
using AlaThuqk.DATA.DTOs.User;
using AlaThuqk.Entities;
using AutoMapper;
using OneSignalApi.Model;
using OrderItem = AlaThuqk.Entities.OrderItem;

// here to implement
using BackEndStructuer.DATA.DTOs.DeliveryPriceDto;
using BackEndStructuer.DATA.DTOs.DeliveryPriceForm;
using BackEndStructuer.DATA.DTOs.DeliveryPriceUpdate;
using BackEndStructuer.Entities;


namespace AlaThuqk.Helpers{
    public class UserMappingProfile : Profile{
        public UserMappingProfile() {
//             CreateMap<ArticleForm, Article>()
//                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
//             CreateMap<ArticleUpdate, Article>()
//                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
//
//             CreateMap<AppUser, UserDto>();
//             CreateMap<RegisterForm, App>()
//                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
//
//             CreateMap<Category, CategoryDto>();
//             CreateMap<CategoryForm, Category>()
//                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
//             CreateMap<CategoryUpdate, Category>()
//                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
//
//             CreateMap<SizeForm, Size>();
//             CreateMap<SizeUpdate, Size>();
//             CreateMap<Size, SizeDto>();
//
//             CreateMap<ProductForm, Product>()
//                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
//
//             CreateMap<ProductUpdate, Product>()
//                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
//
//             CreateMap<ColorForm, Color>()
//                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
//
//             CreateMap<ColorUpdate, Color>()
//                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
//
//             CreateMap<ProductForm, Product>()
//                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
//             CreateMap<Product, ProductDto>()
//                  .ForMember(dest => dest.Quantity,
//                     opt => opt.MapFrom(x => 
//                         x.Sizes.Sum(size => size.Colors.Sum(color => color.Quantity))))
//                  .ForMember(dist 
//                  =>dist.Likes, opt => opt.MapFrom(x => x.UserLikes==null?0:x.UserLikes.Count));
//                  
//
//             CreateMap<ComponentForm, Component>()
//                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
//             CreateMap<ComponentUpdate, Component>()
//                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
//             CreateMap<Component, ComponentdDto>()
//                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
//
//             // CreateMap<OrderForm, Order>()
//             //     .ForMember(dest => dest.UserAddress, opt => opt.MapFrom(src => src.Address)); // Map AddressForm to UserAddress
//
//                 CreateMap<OrderUpdate, Order>()
//                     .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
//
//             // CreateMap<Order, OrderDto>()
//             //     .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.UserAddress));
//             CreateMap<OrderItemForm, Entities.OrderItemProfile>()
//                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
//
//             CreateMap<OrderItemUpdate, Entities.OrderItemProfile>();
//
//             CreateMap<Entities.OrderItemProfile, OrderItemDto>();
//
//             CreateMap<TemplateForm, Template>()
//                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
//
//             CreateMap<TemplateUpdate, Template>();
//
//             CreateMap<Template, TemplateDto>();
//
//             CreateMap<PrintComponentForm, PrintComponent>()
//                 .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
//
//             CreateMap<PrintComponentUpdate, PrintComponent>();
//
//             CreateMap<PrintComponent, PrintComponentDto>();
//             
//             CreateMap<Color, ColorDto>();
//             
//             
//             // here to Add 
// CreateMap<Address, AddressDto>();
// CreateMap<AddressForm,Address>();
// CreateMap<AddressUpdate,Address>();
//
//             
//             

            
        }
    }
}

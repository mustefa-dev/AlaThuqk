using AlaThuqk.DATA.DTOs;
using AlaThuqk.DATA.DTOs.OrderItem;
using AlaThuqk.Entities;
using AutoMapper;

namespace AlaThuqk.Helpers.MapperProfile;

public class OrderItemProfile : Profile{
    public OrderItemProfile() {
        CreateMap<OrderItemForm, OrderItem>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<OrderItemUpdate, OrderItem>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<Entities.OrderItem, OrderItemDto>()
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.ColorText))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}
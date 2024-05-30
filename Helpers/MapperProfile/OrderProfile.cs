using AlaThuqk.DATA.DTOs;
using AlaThuqk.DATA.DTOs.Order;
using AlaThuqk.Entities;
using AutoMapper;

namespace AlaThuqk.Helpers.MapperProfile;

public class OrderProfile : Profile{
    public OrderProfile() {
        CreateMap<OrderForm, Order>();
        CreateMap<OrderUpdate, Order>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.UserAddress));
    }
}
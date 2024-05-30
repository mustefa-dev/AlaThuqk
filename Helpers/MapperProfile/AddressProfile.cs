using AlaThuqk.DATA.DTOs.Address;
using AlaThuqk.Entities;
using AutoMapper;

namespace AlaThuqk.Helpers.MapperProfile{
    public class AddressProfile : Profile{
        public AddressProfile() {
            CreateMap<Address, AddressDto>()
                .ForMember(dest => dest.Governorate, opt => opt.MapFrom(src => src.Governorate.Name))
                .ForAllMembers(
                    opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<AddressForm, Address>();
            CreateMap<AddressUpdate, Address>();
        }
    }
}
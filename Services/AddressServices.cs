using AlaThuqk.DATA.DTOs.Address;
using AlaThuqk.Entities;
using AlaThuqk.Repository;
using AutoMapper;
using BackEndStructuer.DATA.DTOs.AddressFilter;
using Microsoft.EntityFrameworkCore;

namespace AlaThuqk.Services;

public interface IAddressServices{
    Task<(Address? address, string? error)> Create(Guid id, AddressForm addressForm);
    Task<(List<AddressDto> addresss, int? totalCount, string? error)> GetAll(AddressFilter filter);
    Task<(Address? address, string? error)> Update(Guid id, AddressUpdate addressUpdate);
    Task<(Address? address, string? error)> Delete(Guid id);
    Task<(Address? address, string? error)> GetById(Guid id);
    //my address
    Task<(List<AddressDto> addresss, int? totalCount, string? error)> GetMyAddress(AddressFilter filter, Guid userId);
}

public class AddressServices : IAddressServices{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public AddressServices(
        IMapper mapper,
        IRepositoryWrapper repositoryWrapper
    ) {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }


    public async Task<(Address? address, string? error)> Create(Guid id, AddressForm addressForm) {
        var address = _mapper.Map<Address>(addressForm);
        address.UserId = id;
        var result = await _repositoryWrapper.Address.Add(address);
        return result == null ? (null, "address could not Add") : (address, null);
    }

    public async Task<(List<AddressDto> addresss, int? totalCount, string? error)> GetAll(AddressFilter filter) {
        var (address, totalCount) = await _repositoryWrapper.Address.GetAll(
            address1 => address1.Include(address => address.Governorate),
            filter.PageNumber);
        var addresssDto = _mapper.Map<List<AddressDto>>(address);
        return (addresssDto, totalCount, null);
    }

    public async Task<(Address? address, string? error)> GetById(Guid id) {
        var address = await _repositoryWrapper.Address.GetById(id);
        return address == null ? (null, "address not found") : (address, null);
    }

    public async Task<(Address? address, string? error)> Update(Guid id, AddressUpdate addressUpdate) {
        var address = await _repositoryWrapper.Address.GetById(id);
        if (address == null) {
            return (null, "address not found");
        }

        address = _mapper.Map(addressUpdate, address);
        var response = await _repositoryWrapper.Address.Update(address);
        return response == null ? (null, "address could not be updated") : (address, null);
    }

    public async Task<(Address? address, string? error)> Delete(Guid id) {
        var address = await _repositoryWrapper.Address.GetById(id);
        if (address == null) return (null, "address not found");
        var response = await _repositoryWrapper.Address.Delete(id);
        return response == null ? (null, "address could not be deleted") : (address, null);
    }
    public async    Task<(List<AddressDto> addresss, int? totalCount, string? error)> GetMyAddress(AddressFilter filter, Guid userId) {
        var (address, totalCount) = await _repositoryWrapper.Address.GetAll(
            address1 => address1.UserId == userId,
            addresss => addresss.Include(address => address.User)
                .ThenInclude(user => user.Addresses )
                .ThenInclude(address1 =>address1.Governorate ),
            filter.PageNumber, filter.PageSize);

        var addresssDto = _mapper.Map<List<AddressDto>>(address);
        return (addresssDto, totalCount, null);
    }
}
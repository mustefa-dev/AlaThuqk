using AlaThuqk.DATA.DTOs.Address;
using AlaThuqk.Entities;
using AlaThuqk.Services;
using BackEndStructuer.DATA.DTOs.AddressFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlaThuqk.Controllers;

public class AddresssController : BaseController{
    private readonly IAddressServices _addressServices;

    public AddresssController(IAddressServices addressServices) {
        _addressServices = addressServices;
    }


    [HttpGet]
    public async Task<ActionResult<List<AddressDto>>> GetAll([FromQuery] AddressFilter filter) =>
        Ok(await _addressServices.GetAll(filter), filter.PageNumber);

    [HttpGet("{id}")]
    public async Task<ActionResult<Address>> GetById(Guid id) => Ok(await _addressServices.GetById(id));


    [HttpPost]
    public async Task<ActionResult<Address>> Create([FromBody] AddressForm addressForm) => Ok(
        await _addressServices.Create(Id, addressForm));


    [HttpPut("{id}")]
    public async Task<ActionResult<Address>> Update([FromBody] AddressUpdate addressUpdate, Guid id) =>
        Ok(await _addressServices.Update(id, addressUpdate));

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Address>> Delete(Guid id) => Ok(await _addressServices.Delete(id));
    [HttpGet("MyAddress")]
    public async Task<ActionResult<List<AddressDto>>> GetMyAddress([FromQuery] AddressFilter filter) =>
        Ok(await _addressServices.GetMyAddress(filter, Id), filter.PageNumber);
}

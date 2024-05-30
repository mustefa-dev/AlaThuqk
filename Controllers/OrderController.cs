using AlaThuqk.DATA.DTOs;
using AlaThuqk.DATA.DTOs.Order;
using AlaThuqk.Services;
using AlaThuqk.Properties;
using Microsoft.AspNetCore.Mvc;

namespace AlaThuqk.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : BaseController
    {
        private readonly IOrderServices _orderServices;

        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetOrder([FromQuery]BaseFilter baseFilter)=> Ok(await _orderServices.GetAll(baseFilter), baseFilter.PageNumber);        
        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] OrderForm orderForm) => Ok(await _orderServices.Add(orderForm,Id));

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderUpdate orderUpdate, Guid id)
        {
            var result = await _orderServices.Update(orderUpdate, id);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var result = await _orderServices.Delete(id);
            return Ok(result);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var result = await _orderServices.GetById(id);
            return Ok(result);
        }
        
        [HttpGet]
        [Route("MyOrders")]
        public async Task<IActionResult> GetMyOrders([FromQuery]BaseFilter baseFilter) => Ok(await _orderServices.GetMyOrders(baseFilter,Id), baseFilter.PageNumber);
    }
}
// using AlaThuqk.DATA.DTOs;
// using AlaThuqk.Services;
// using AlaThuqk.Properties;
// using Microsoft.AspNetCore.Mvc;
//
// namespace AlaThuqk.Controllers
// {
//     
//     [ApiController]
//     [Route("api/[controller]")]
//     public class OrderItemController : BaseController
//     {
//         private readonly IOrderItemServices _orderitemServices;
//
//         public OrderItemController(IOrderItemServices orderitemServices)
//         {
//             _orderitemServices = orderitemServices;
//         }
//         
//         [HttpGet]
//         public async Task<IActionResult> GetOrderItem(int pageNumber = 1)=> Ok(await _orderitemServices.GetAll(pageNumber),pageNumber);
//         
//         [HttpPost]
//         public async Task<IActionResult> AddOrderItem([FromBody] OrderItemForm orderitemForm) => Ok(await _orderitemServices.Add(orderitemForm));
//
//         
//         [HttpPut("{id}")]
//         public async Task<IActionResult> UpdateOrderItem([FromBody] OrderItemUpdate orderitemUpdate, Guid id)
//         {
//             var result = await _orderitemServices.Update(orderitemUpdate, id);
//             return Ok(result);
//         }
//         
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteOrderItem(Guid id)
//         {
//             var result = await _orderitemServices.Delete(id);
//             return Ok(result);
//         }
//         
//     }
// }
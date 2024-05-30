using AlaThuqk.DATA.DTOs;
using AlaThuqk.DATA.DTOs.Product;
using AlaThuqk.Services;
using AlaThuqk.Properties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlaThuqk.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseController{
        private readonly IProductServices _productServices;


        public ProductController(IProductServices productServices) {
            _productServices = productServices;
        }


        [HttpGet]
        public async Task<IActionResult> GetProduct([FromQuery] ProductFilter baseFilter) =>
            Ok(await _productServices.GetAll(baseFilter, Id), baseFilter.PageNumber);

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id) => Ok(await _productServices.GetById(id, Id));

        [HttpGet]
        [Route("{id}/Sizes")]
        public async Task<IActionResult> GetProductSizes(Guid id) => Ok(await _productServices.GetSizes(id));

        [HttpGet]
        [Route("{id}/Sizes/{sizeId}/Colors")]
        public async Task<IActionResult> GetProductColors(Guid id, Guid sizeId) =>
            Ok(await _productServices.GetColors(id, sizeId));

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductForm productForm) =>
            Ok(await _productServices.Add(productForm));


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductUpdate productUpdate, Guid id) {
            var result = await _productServices.update(productUpdate, id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id) {
            var result = await _productServices.Delete(id);
            return Ok(result);
        }

        [HttpGet("MostSoldProduct")]
        public async Task<IActionResult> GetMostSoldProduct([FromQuery] ProductFilter filter) {
            var result = await _productServices.GetMostSoldProducts(filter);
            return Ok(result, filter.PageNumber);
        }

        [HttpPost("{id}/LikeUnlike")]
        public async Task<IActionResult> LikeUnlikeProduct(Guid id) {
            var result = await _productServices.LikeUnlikeProduct(Id, id);
            return Ok(result);
        }

        [HttpGet("MostLikedProduct")]
        public async Task<IActionResult> GetMostLikedProduct([FromQuery] ProductFilter filter) {
            var result = await _productServices.GetMostLikedTemplate(filter);
            return Ok(result, filter.PageNumber);
        }
        [Authorize]

        [HttpGet("MyLikedProducts")]
        public async Task<IActionResult> GetMyLikedProducts([FromQuery] ProductFilter filter) {
            var result = await _productServices.GetMyLikedProducts(filter, Id);
            return Ok(result, filter.PageNumber);
        }
    }
}
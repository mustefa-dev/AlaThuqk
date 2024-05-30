using AlaThuqk.DATA.DTOs;
using AlaThuqk.DATA.Filter;
using AlaThuqk.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlaThuqk.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class TemplateController : BaseController{
        private readonly ITemplateServices _templateServices;

        public TemplateController(ITemplateServices templateServices) {
            _templateServices = templateServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TemplateFilter baseFilter) =>
            Ok(await _templateServices.GetAll(baseFilter, Id), baseFilter.PageNumber);

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id) => Ok(await _templateServices.GetById(id, Id));

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TemplateForm templateForm) =>
            Ok(await _templateServices.Add(templateForm));
        
        [HttpGet]
        [Route("{id}/Sizes")]
        public async Task<IActionResult> GetProductSizes(Guid id) => Ok(await _templateServices.GetSizes(id));


        [HttpGet]
        [Route("{id}/Sizes/{sizeId}/Colors")]
        public async Task<IActionResult> GetProductColors(Guid id, Guid sizeId) =>
            Ok(await _templateServices.GetColors(id, sizeId));
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] TemplateUpdate templateUpdate, Guid id) {
            var result = await _templateServices.update(templateUpdate, id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id) {
            var result = await _templateServices.Delete(id);
            return Ok(result);
        }

        [HttpGet("MostSoldProduct")]
        public async Task<IActionResult> GetMostSoldProduct([FromQuery] TemplateFilter filter) {
            var result = await _templateServices.GetMostSoldTemplates(filter);
            return Ok(result, filter.PageNumber);
        }

        [HttpPost("{id}/LikeUnlike")]
        public async Task<IActionResult> LikeUnlikeProduct(Guid id) {
            var result = await _templateServices.LikeUnlikeTemplate(Id, id);
            return Ok(result);
        }

        [HttpGet("MostLikedProduct")]
        public async Task<IActionResult> GetMostLikedTemplate([FromQuery] TemplateFilter filter) {
            var result = await _templateServices.GetMostLikedTemplate(filter);
            return Ok(result, filter.PageNumber);
        }
        [Authorize]
        [HttpGet("MyLikedProduct")]
        public async Task<IActionResult> GetMyLikedTemplate([FromQuery] TemplateFilter filter) {
            var result = await _templateServices.GetMyLikedTemplate(filter, Id);
            return Ok(result, filter.PageNumber);
        }

        
    }
}
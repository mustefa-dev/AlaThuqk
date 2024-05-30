using AlaThuqk.DATA.DTOs.Size;
using AlaThuqk.Services;
using AlaThuqk.DATA.DTOs;
using AlaThuqk.Properties;
using Microsoft.AspNetCore.Mvc;

namespace AlaThuqk.Controllers
{
    public class SizeController : BaseController
    {
        private readonly ISizeServices _sizeServices;

        public SizeController(ISizeServices sizeServices)
        {
            _sizeServices = sizeServices;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetSize([FromQuery]BaseFilter baseFilter)=> Ok(await _sizeServices.GetAll(baseFilter), baseFilter.PageNumber);        
        [HttpPost]
        public async Task<IActionResult> AddSize([FromBody] SizeForm sizeForm) => Ok(await _sizeServices.add(sizeForm));
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSizeById(Guid id) => Ok(await _sizeServices.GetById(id));

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSize([FromBody] SizeUpdate sizeUpdate, Guid id)
        {
            var result = await _sizeServices.update(sizeUpdate, id);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSize(Guid id)
        {
            var result = await _sizeServices.Delete(id);
            return Ok(result);
        }
        
    }
}
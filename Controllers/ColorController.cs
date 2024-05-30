using AlaThuqk.DATA.DTOs.Color;
using AlaThuqk.Services;
using AlaThuqk.DATA.DTOs;
using AlaThuqk.Properties;
using Microsoft.AspNetCore.Mvc;

namespace AlaThuqk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColorController : BaseController
    {
        private readonly IColorServices _colorServices;

        public ColorController(IColorServices colorServices)
        {
            _colorServices = colorServices;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetColor([FromQuery]BaseFilter baseFilter)=> Ok(await _colorServices.GetAll(baseFilter), baseFilter.PageNumber);        
        [HttpPost]
        public async Task<IActionResult> AddColor([FromBody] ColorForm colorForm) => Ok(await _colorServices.add(colorForm));
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetColorById(Guid id) => Ok(await _colorServices.GetById(id));

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateColor([FromBody] ColorUpdate colorUpdate, Guid id)
        {
            var result = await _colorServices.update(colorUpdate, id);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColor(Guid id)
        {
            var result = await _colorServices.Delete(id);
            return Ok(result);
        }
        
    }
}
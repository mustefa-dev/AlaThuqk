using AlaThuqk.DATA.DTOs;
using AlaThuqk.DATA.DTOs.Category;
using AlaThuqk.Services;
using AlaThuqk.Properties;
using Microsoft.AspNetCore.Mvc;

namespace AlaThuqk.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetCategory([FromQuery]BaseFilter baseFilter)=> Ok(await _categoryServices.GetAll(baseFilter), baseFilter.PageNumber);
        
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryForm categoryForm) => Ok(await _categoryServices.add(categoryForm));
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id) => Ok(await _categoryServices.GetById(id));

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryUpdate categoryUpdate, Guid id)
        {
            var result = await _categoryServices.update(categoryUpdate, id);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var result = await _categoryServices.Delete(id);
            return Ok(result);
        }
        
    }
}
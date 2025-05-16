using Business.Abstract;
using Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost("add")]
        public IActionResult AddCategory(CategoryDto categoryDto)
        {
            var result = _categoryService.Add(categoryDto);
            return result.Success
               ? Ok(result)
               : BadRequest(result);
        }
        [HttpDelete("delete/{categoryId}")]
        public IActionResult DeleteCategory(Guid categoryId)
        {
            var result = _categoryService.Delete(categoryId);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
        [HttpPut("update/{categoryId}")]
        public IActionResult UpdateCategory(CategoryDto categoryDto , Guid categoryId)
        {
            var result = _categoryService.Update(categoryDto, categoryId);
            return result.Success 
                ? Ok(result) 
                : BadRequest(result);
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
        [HttpGet("getById/{categoryId}")]
        public IActionResult GetByCategoryId(Guid categoryId)
        {
            var result = _categoryService.GetById(categoryId);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
        [HttpGet("getByName/{categoryName}")]
        public IActionResult GetByCategoryName(string categoryName)
        {
            var result = _categoryService.GetByName(categoryName);
            return result.Success
                ? Ok(result)
                : BadRequest(result);
        }
    }
}

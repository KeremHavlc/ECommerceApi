using Business.Abstract;
using Core.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("add")]
        public IActionResult Add(ProductDto productDto)
        {
            var result = _productService.Add(productDto);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
        [HttpDelete("delete/{productId}")]
        public IActionResult Delete(Guid productId)
        {
            var result = _productService.Delete(productId);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
        [HttpPut("update/{productId}")]
        public IActionResult Update(ProductDto productDto, Guid productId)
        {
            var result = _productService.Update(productDto, productId);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }
        [HttpGet("getbyid/{productId}")]
        public IActionResult GetById(Guid productId)
        {
            var result = _productService.GetById(productId);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }
        [HttpGet("getbyname/{productName}")]
        public IActionResult GetByName(string productName)
        {
            var result = _productService.GetByName(productName);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }
        [HttpGet("getbycategoryname/{categoryName}")]
        public IActionResult GetByCategoryName(string categoryName)
        {
            var result = _productService.GetByCategoryName(categoryName);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }
        [HttpGet("getbycategoryid/{categoryId}")]
        public IActionResult GetByCategoryId(Guid categoryId)
        {
            var result = _productService.GetByCategoryId(categoryId);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);

        }
    }
}

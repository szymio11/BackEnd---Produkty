using System;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Produkty.Data.ModelsDto;
using Produkty.Service.Interfaces;

namespace Produkty.API.Controllers
{
    [Route("/api/product")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] UploadProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var product = await _service.CreateProductAsync(productDto);
            return CreatedAtRoute("GetProduct", new { productId = product.Id}, product);
        }
        [HttpGet("{productId}", Name="GetProduct")]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            if (!await _service.IsExist(productId))
            {
                return NotFound("Nie ma takiego produktu.");
            }

            var product = await _service.GetProductAsync(productId);
            return Ok(product);
        }
        [HttpPut("{productId}")]
        public async Task<IActionResult> UploadProduct([FromBody] UploadProductDto productDto,Guid productId)
        {
            if (!await _service.IsExist(productId))
            {
                return NotFound("Nie ma takiego produktu.");
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _service.UploadProduct(productDto,productId);
            return Ok();
        }
        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            if (!await _service.IsExist(productId))
            {
                return NotFound("Nie ma takiego produktu.");
            }

            await _service.DeleteProduct(productId);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            if (!await _service.IsAnyExistAsync())
            {
                return NotFound("Nie ma żadnego produktu na liscie.");
            }
            var result = await _service.GetAllProductsAsync();

            return Ok(result);
        }
    }
}
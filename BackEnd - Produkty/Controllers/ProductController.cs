using System;
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
        public async Task<IActionResult> Create([FromBody] UploadProductDto productDto)
        {
            return NotFound();
        }
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            if (!await _service.IsExist(productId))
            {
                return NotFound("Nie ma takiego produktu");
            }

            var product = await _service.GetProduct(productId);
            return Ok(product);
        }
    }
}
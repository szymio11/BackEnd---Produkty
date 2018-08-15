using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Produkty.Service.Interfaces;

namespace Produkty.API.Controllers
{
    [Route("api/categories")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            var categories = await _service.GetAllAsync();
            if (categories==null)
            {
                return NotFound();
            }
            return Ok(categories);

        }
    }
}
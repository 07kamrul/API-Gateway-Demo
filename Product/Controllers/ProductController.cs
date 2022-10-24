using Microsoft.AspNetCore.Mvc;
using Product.Services;

namespace Product.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        private IProductService productService;
        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        [Produces("application/json")]
        [HttpGet("findall")]
        public IActionResult FindAll()
        {
            try
            {
                return Ok(productService.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

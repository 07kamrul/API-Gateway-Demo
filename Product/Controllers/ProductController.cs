using Microsoft.AspNetCore.Mvc;
using Product.Services;

namespace Product.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {        
        private IProductService productService;
        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

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

        [HttpGet]
        public List<string> Get()
        {
            var productList = new List<string>
            {
                "Product 01",
                "Product 02",
                "Product 03",
                "Product 04",
                "Product 05",
            };
            return productList;
        }

    }
}

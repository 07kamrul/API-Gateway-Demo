using Catalog.Services;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("api/catalog")]
    public class CatalogController : ControllerBase
    {
        /*        private ICatalogService catalogService;
                public CatalogController(ICatalogService _catalogService)
                {
                    catalogService = _catalogService;
                }

                [Produces("application/json")]
                [HttpGet("findall")]
                public IActionResult FindAll()
                {
                    try
                    {
                        return Ok(catalogService.FindAll());
                    }
                    catch
                    {
                        return BadRequest();
                    }
                }*/

        [HttpGet]
        public List<string> Get()
        {
            var productList = new List<string>
            {
                "Catalog 01",
                "Catalog 02",
                "Catalog 03",
                "Catalog 04"
            };
            return productList;
        }
    }
}

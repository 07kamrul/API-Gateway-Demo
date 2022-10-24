using Catalog.Services;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [Route("api/catalog")]
    public class CatalogController : Controller
    {
        private ICatalogService catalogService;
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
        }
    }
}

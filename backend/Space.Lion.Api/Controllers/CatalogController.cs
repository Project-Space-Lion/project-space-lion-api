using Microsoft.AspNetCore.Mvc;
using Space.Lion.Domain.Catalog;

namespace Space.Lion.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        [HtttpGet]
        public IActionResult GetItems()
        {
            return Ok("hello world. ");
        }
    }
}
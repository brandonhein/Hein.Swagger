using Hein.Swagger.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hein.Swagger.Sample.Controllers
{
    [SwaggerOrder(3)]
    [Route("apple")]
    public class AppleController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}

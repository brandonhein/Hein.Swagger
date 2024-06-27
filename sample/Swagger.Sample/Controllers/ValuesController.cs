using Hein.Swagger.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hein.Swagger.Sample.Controllers
{
    [SwaggerOrder(2)]
    [SwaggerController("Values")]
    [Route("values")]
    public class ValuesController : Controller
    {
        [SwaggerOrder(9)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = new List<object>()
            {
                new { id = 1, name = $"value_1" },
                new { id = 2, name = $"value_2" }
            };

            return Ok(values);
        }

        [SwaggerOrder(10)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute][Description("des")] int id)
        {
            return Ok(new { id = id, name = $"value_{id}" });
        }

        [SwaggerOrder(1)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            return Ok();
        }

        [SwaggerOrder(2)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] string value)
        {
            return Ok();
        }

        [SwaggerOrder(3)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}

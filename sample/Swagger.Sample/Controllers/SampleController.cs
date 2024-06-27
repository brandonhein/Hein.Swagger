using Hein.Swagger.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Hein.Swagger.Sample.Controllers
{
    [SwaggerOrder(1)]
    [SwaggerController("LookMom")]
    [Route("Sample")]
    public class SampleController : Controller
    {
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SampleModel), 200)]
        public IActionResult Get()
        {
            return Ok(new SampleModel() { DateTime = DateTime.Now, Name = "sample-item", Version = new Random().Next() });
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesHeader("x-collection-count", SwaggerType.Integer, "sample response header")]
        [ProducesHeader("x-another-count", "another header attribute")]
        [ProducesResponseType(typeof(SampleModel), 200)]
        [Description("Post Description")]
        [Summary("Ope")]
        public IActionResult Post([FromBody] SampleModel model)
        {
            return Ok(model);
        }
    }

    public class SampleModel
    {
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public int Version { get; set; }
    }
}

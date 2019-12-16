using Hein.Swagger.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Hein.Swagger.Sample.Contorllers
{
    [Swagger]
    [Route("Sample")]
    public class SampleController : Controller
    {
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SampleModel), 200)]
        public IActionResult Get()
        {
            return Ok(new SampleModel() { DateTime = DateTime.Now, Name = "sample-item", Version = 1 });
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SampleModel), 200)]
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

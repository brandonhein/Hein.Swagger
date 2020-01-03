using Hein.Swagger.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Hein.Swagger.Sample.Controllers
{
    [ExcludeFromSwagger]
    [Route("Exclude")]
    public class ExcludeController : Controller
    {
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ExcludeModel), 200)]
        public IActionResult Get()
        {
            return Ok(new ExcludeModel() { DateTime = DateTime.Now, Name = "sample-item", Version = 1 });
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ExcludeModel), 200)]
        public IActionResult Post([FromBody] ExcludeModel model)
        {
            return Ok(model);
        }
    }

    public class ExcludeModel
    {
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public int Version { get; set; }
    }
}

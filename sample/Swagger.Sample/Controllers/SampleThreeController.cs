using Hein.Swagger.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Hein.Swagger.Sample.Controllers
{
    [SwaggerVersion("v1")]
    [SwaggerController("LookMom")]
    [Route("Sample")]
    public class SampleThreeController : Controller
    {
        [HttpDelete]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SampleModel), 200)]
        public IActionResult Delete()
        {
            return Ok(new SampleModel() { DateTime = DateTime.Now, Name = "sample-item", Version = 1 });
        }

        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SampleModel), 200)]
        public IActionResult Put([FromBody] SampleModel model)
        {
            return Ok(model);
        }
    }
}

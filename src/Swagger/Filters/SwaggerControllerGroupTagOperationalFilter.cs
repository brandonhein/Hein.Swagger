using Hein.Swagger.Attributes;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace Hein.Swagger.Filters
{
    public class SwaggerControllerGroupTagOperationalFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var attr = context.ApiDescription.ControllerAttributes()
                .OfType<SwaggerTagAttribute>().FirstOrDefault();

            if (attr != null)
            {
                if (!operation.Tags.Select(x => x.Name).Contains(attr.TagName))
                {
                    var descriptor = (dynamic)context.ApiDescription.ActionDescriptor;
                    var name = (string)descriptor.ControllerName;

                    var tags = operation.Tags.ToList();
                    tags.Add(new OpenApiTag() { Name = attr.TagName });
                    tags.RemoveAll(x => x.Name == name);
                    operation.Tags = tags;
                }
            }
        }
    }
}

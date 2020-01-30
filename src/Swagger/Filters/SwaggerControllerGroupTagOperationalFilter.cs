using Hein.Swagger.Attributes;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace Hein.Swagger.Filters
{
    public class SwaggerControllerGroupTagOperationalFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var attr = context.ApiDescription.ControllerAttributes()
                .OfType<SwaggerTagAttribute>().FirstOrDefault();

            if (attr != null)
            {
                if (!operation.Tags.Contains(attr.TagName))
                {
                    var descriptor = (dynamic)context.ApiDescription.ActionDescriptor;
                    var name = (string)descriptor.ControllerName;

                    var tags = operation.Tags.ToList();
                    tags.Add(attr.TagName);
                    tags.Remove(name);
                    operation.Tags = tags;
                }
            }
        }
    }
}

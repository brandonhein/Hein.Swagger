using Hein.Swagger.Attributes;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace Hein.Swagger.Filters
{
    public class SwaggerDescriptionFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var actionAttr = context.ApiDescription.ActionAttributes()
                .OfType<SwaggerDescriptionAttribute>().FirstOrDefault();

            if (actionAttr != null)
            {
                operation.Description = actionAttr.Description;
            }
        }
    }
}

using Hein.Swagger.Attributes;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace Hein.Swagger.Filters
{
    public class SwaggerSummaryFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var actionAttr = context.ApiDescription.ActionAttributes()
                .OfType<SwaggerSummaryAttribute>().FirstOrDefault();

            if (actionAttr != null)
            {
                operation.Summary = actionAttr.Summary;
            }
        }
    }
}

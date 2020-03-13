using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace Hein.Swagger.Filters
{
    public class SwaggerUniqueOperationIdFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            operation.OperationId = Guid.NewGuid().ToString();
        }
    }
}

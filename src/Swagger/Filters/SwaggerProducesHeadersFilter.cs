using Hein.Swagger.Attributes;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace Hein.Swagger.Filters
{
    public class SwaggerProducesHeadersFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var actionAttrs = context.ApiDescription.ActionAttributes()
                .OfType<ProducesHeaderAttribute>();

            if (actionAttrs != null && actionAttrs.Any())
            {
                foreach (var actionAttr in actionAttrs)
                {
                    foreach (var response in operation.Responses)
                    {
                        if (response.Value.Headers == null)
                        {
                            response.Value.Headers = new Dictionary<string, Header>();
                        }

                        if (!actionAttr.StatusCode.HasValue || 
                            (actionAttr.StatusCode.HasValue && actionAttr.StatusCode.Value.ToString() == response.Key))
                        {
                            response.Value.Headers.Add(actionAttr.Header, new Header()
                            {
                                Type = actionAttr.ValueType.ToString().ToLower(),
                                Description = actionAttr.Description
                            });
                        }
                    }
                }
            }
        }
    }
}

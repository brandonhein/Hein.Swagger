using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace Hein.Swagger.Filters
{
    public class SwaggerRateLimitHeaders : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Responses.Add("429", new OpenApiResponse { Description = "Too Many Requests" });

            foreach (var response in operation.Responses)
            {
                if (response.Value.Headers == null)
                {
                    response.Value.Headers = new Dictionary<string, OpenApiHeader>();
                }
                response.Value.Headers.Add("X-Rate-Limit-Limit", new OpenApiHeader() { Description = "The number of allowed requests in the current period" });
                response.Value.Headers.Add("X-Rate-Limit-Remaining", new OpenApiHeader() { Description = "The number of remaining requests in the current period" });
                response.Value.Headers.Add("X-Rate-Limit-Reset", new OpenApiHeader() { Description = "The number of seconds left in the current period" });
            }
        }
    }
}

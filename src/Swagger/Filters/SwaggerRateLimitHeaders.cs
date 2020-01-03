using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace Hein.Swagger.Filters
{
    public class SwaggerRateLimitHeaders : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            operation.Responses.Add("429", new Response { Description = "Too Many Requests" });

            foreach (var response in operation.Responses)
            {
                if (response.Value.Headers == null)
                {
                    response.Value.Headers = new Dictionary<string, Header>();
                }
                response.Value.Headers.Add("X-Rate-Limit-Limit", new Header() { Type = "integer", Description = "The number of allowed requests in the current period" });
                response.Value.Headers.Add("X-Rate-Limit-Remaining", new Header() { Type = "integer", Description = "The number of remaining requests in the current period" });
                response.Value.Headers.Add("X-Rate-Limit-Reset", new Header() { Type = "integer", Description = "The number of seconds left in the current period" });
            }
        }
    }
}

using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace Hein.Swagger.Filters
{
    public class GithubRepositoryDocumentFilter : IDocumentFilter
    {
        private readonly string _repositoryUrl;
        public GithubRepositoryDocumentFilter(string repositoryUrl)
        {
            _repositoryUrl = repositoryUrl;
        }

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.ExternalDocs = new OpenApiExternalDocs()
            {
                Description = "GitHub Repository",
                Url = new Uri(_repositoryUrl)
            };
        }
    }
}

using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Hein.Swagger.Filters
{
    public class GithubRepositoryDocumentFilter : IDocumentFilter
    {
        private readonly string _repositoryUrl;
        public GithubRepositoryDocumentFilter(string repositoryUrl)
        {
            _repositoryUrl = repositoryUrl;
        }

        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.ExternalDocs = new ExternalDocs()
            {
                Description = "GitHub Repository",
                Url = _repositoryUrl
            };
        }
    }
}

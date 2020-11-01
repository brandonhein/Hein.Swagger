using Microsoft.OpenApi.Models;

namespace Hein.Swagger.Security.Keys
{
    public class OAuthScheme : SecuritySchemeBase
    {
        public OAuthScheme(string name, OAuthGrantType oauthType, OpenApiOAuthFlow flow, string description = null)
        {
            base.Reference = new OpenApiReference()
            {
                Type = ReferenceType.SecurityScheme,
                Id = name.Replace("-", "")
            };

            base.Name = name;
            base.Description = description;
            base.Type = SecuritySchemeType.OAuth2;

            base.Flows = new OpenApiOAuthFlows()
            {
                Implicit = oauthType == OAuthGrantType.Implicit ? flow : null,
                AuthorizationCode = oauthType == OAuthGrantType.Authorization ? flow : null,
                ClientCredentials = oauthType == OAuthGrantType.ClientCredentials ? flow : null,
                Password = oauthType == OAuthGrantType.Password ? flow : null,
            };
        }
    }
}

using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace Hein.Swagger.Security
{
    public class OAuthAuthorizationFlowDetail
    {
        /// <summary>
        /// The authorization URL to use for this flow. Can be relative to the API server URL.
        /// </summary>
        public Uri AuthorizationUrl { get; set; }
        /// <summary>
        /// The token URL to use for this flow. Can be relative to the API server URL.
        /// </summary>
        public Uri TokenUrl { get; set; }
        /// <summary>
        /// Optional. The URL to be used for obtaining refresh tokens. Can be relative to the API server URL.
        /// </summary>
        public Uri RefreshUrl { get; set; }
        /// <summary>
        /// The available scopes for the OAuth2 security scheme. A map between the scope name and a short description for it.
        /// </summary>
        public IDictionary<string, string> Scopes { get; set; }

        public OpenApiOAuthFlow ToOpenApiAuthFlow()
        {
            return new OpenApiOAuthFlow() { AuthorizationUrl = AuthorizationUrl, RefreshUrl = RefreshUrl, TokenUrl = TokenUrl, Scopes = Scopes };
        }
    }

    public class OAuthImplicitFlowDetail
    {
        /// <summary>
        /// The authorization URL to use for this flow. Can be relative to the API server URL.
        /// </summary>
        public Uri AuthorizationUrl { get; set; }
        /// <summary>
        /// Optional. The URL to be used for obtaining refresh tokens. Can be relative to the API server URL.
        /// </summary>
        public Uri RefreshUrl { get; set; }
        /// <summary>
        /// The available scopes for the OAuth2 security scheme. A map between the scope name and a short description for it.
        /// </summary>
        public IDictionary<string, string> Scopes { get; set; }

        public OpenApiOAuthFlow ToOpenApiAuthFlow()
        {
            return new OpenApiOAuthFlow() { AuthorizationUrl = AuthorizationUrl, RefreshUrl = RefreshUrl, Scopes = Scopes };
        }
    }

    public class OAuthPasswordFlowDetail
    {
        /// <summary>
        /// The token URL to use for this flow. Can be relative to the API server URL.
        /// </summary>
        public Uri TokenUrl { get; set; }
        /// <summary>
        /// Optional. The URL to be used for obtaining refresh tokens. Can be relative to the API server URL.
        /// </summary>
        public Uri RefreshUrl { get; set; }
        /// <summary>
        /// The available scopes for the OAuth2 security scheme. A map between the scope name and a short description for it.
        /// </summary>
        public IDictionary<string, string> Scopes { get; set; }

        public OpenApiOAuthFlow ToOpenApiAuthFlow()
        {
            return new OpenApiOAuthFlow() { RefreshUrl = RefreshUrl, TokenUrl = TokenUrl, Scopes = Scopes };
        }
    }

    public class OAuthClientCredentialsFlowDetail
    {
        /// <summary>
        /// The token URL to use for this flow. Can be relative to the API server URL.
        /// </summary>
        public Uri TokenUrl { get; set; }
        /// <summary>
        /// Optional. The URL to be used for obtaining refresh tokens. Can be relative to the API server URL.
        /// </summary>
        public Uri RefreshUrl { get; set; }
        /// <summary>
        /// The available scopes for the OAuth2 security scheme. A map between the scope name and a short description for it.
        /// </summary>
        public IDictionary<string, string> Scopes { get; set; }

        public OpenApiOAuthFlow ToOpenApiAuthFlow()
        {
            return new OpenApiOAuthFlow() { RefreshUrl = RefreshUrl, TokenUrl = TokenUrl, Scopes = Scopes };
        }
    }
}

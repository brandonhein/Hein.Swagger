using Hein.Swagger.Filters;
using Hein.Swagger.Security;
using Hein.Swagger.Security.Keys;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Hein.Swagger
{
    public static class SwaggerGenSecurityExtensions
    {
        /// <summary>
        /// https://swagger.io/docs/specification/authentication/api-keys/
        /// <para>An API key is a token that a client provides when making API calls. The key can be sent in the query string.</para>
        /// <para>API keys are supposed to be a secret that only the client and server know. Like Basic authentication, API key-based authentication is only considered secure if used together with other security mechanisms such as HTTPS/SSL.</para>
        /// <para>For example, an api that requires 'api_key' as a query string value, the client would make an API call to a URL like this: [~/someResource?api_key=abcdef12345]</para>
        /// </summary>
        /// <param name="queryName">Required. The Query String value thats required to pass into the API Request</param>
        /// <param name="description">Optional. Describe the API Key, or provied details on how to obtain a key</param>
        public static void AddQueryKey(this SwaggerGenOptions options, string queryName, string description = null)
        {
            options.OperationFilter<SwaggerUniqueOperationIdFilter>();
            var scheme = new QueryStringScheme(queryName, description);
            options.DocumentFilter<SwaggerSecurityDocumentFilter>(scheme);
            options.OperationFilter<SwaggerSecurityOperationalFilter>(scheme);
        }

        /// <summary>
        /// https://swagger.io/docs/specification/authentication/api-keys/
        /// <para>An API key is a token that a client provides when making API calls. The key can be sent in a request header.</para>
        /// <para>API keys are supposed to be a secret that only the client and server know. Like Basic authentication, API key-based authentication is only considered secure if used together with other security mechanisms such as HTTPS/SSL.</para>
        /// <para>For example, an api that requires 'x-api-key' as a header value, the client would send this header: [x-api-key: abcdef12345]</para>
        /// </summary>
        /// <param name="headerName">Required. The Header Key value thats required to pass into the API Request</param>
        /// <param name="description">Optional. Describe the API Key, or provied details on how to obtain a key</param>
        public static void AddHeaderKey(this SwaggerGenOptions options, string headerName, string description = null)
        {
            options.OperationFilter<SwaggerUniqueOperationIdFilter>();
            var scheme = new HeaderScheme(headerName, description);
            options.DocumentFilter<SwaggerSecurityDocumentFilter>(scheme);
            options.OperationFilter<SwaggerSecurityOperationalFilter>(scheme);
        }

        /// <summary>
        /// https://swagger.io/docs/specification/authentication/cookie-authentication/
        /// </summary>
        /// <param name="cookieName">Required. The Cookie Key value thats required to pass into the API Request</param>
        /// <param name="description">Optional. Describe the API Key, or provied details on how to obtain a key</param>
        public static void AddCookieKey(this SwaggerGenOptions options, string cookieName, string description = null)
        {
            options.OperationFilter<SwaggerUniqueOperationIdFilter>();
            var scheme = new CookieScheme(cookieName, description);
            options.DocumentFilter<SwaggerSecurityDocumentFilter>(scheme);
            options.OperationFilter<SwaggerSecurityOperationalFilter>(scheme);
        }

        /// <summary>
        /// https://swagger.io/docs/specification/authentication/basic-authentication/
        /// <para>Basic authentication is a simple authentication scheme built into the HTTP protocol. The client sends HTTP requests with the Authorization header that contains the word Basic word followed by a space and a base64-encoded string username:password. </para>
        /// <para>For example, to authorize as demo / p@55w0rd the client would send this header: [Authorization: Basic ZGVtbzpwQDU1dzByZA==]</para>
        /// </summary>
        /// <param name="basicAuthName">Optional. Give a specific name for this Auth. If nothing provided, default value = 'Basic Auth'</param>
        /// <param name="description">Optional. Describe what values to use or where to obtain a username password. If nothing provided, default value = 'Basic Authentication Credentials'</param>
        public static void AddBasicAuthentication(this SwaggerGenOptions options, string basicAuthName = null, string description = null)
        {
            options.OperationFilter<SwaggerUniqueOperationIdFilter>();
            var scheme = new BasicScheme(
                !string.IsNullOrEmpty(basicAuthName) ? basicAuthName : "Basic Auth",
                !string.IsNullOrEmpty(description) ? description : "Basic Authentication Credentials");
            options.DocumentFilter<SwaggerSecurityDocumentFilter>(scheme);
            options.OperationFilter<SwaggerSecurityOperationalFilter>(scheme);
        }

        /// <summary>
        /// https://swagger.io/docs/specification/authentication/bearer-authentication/
        /// <para>Bearer authentication (also called token authentication) is an HTTP authentication scheme that involves security tokens called bearer tokens. The name "Bearer authentication" can be understood as "give access to the bearer of this token." The bearer token is a cryptic string, usually generated by the server in response to a login request. </para>
        /// <para>The client must send this token in the Authorization header when making requests to protected resources: [Authorization: Bearer {token}]</para>
        /// </summary>
        /// <param name="bearerAuthName">Optional. Give a specific name for this Auth. If nothing provided, default value = 'Bearer'</param>
        /// <param name="description">Optional. Give some details into this Auth. Maybe some instructions on how to obtain an auth token, If nothing provided, default value = 'Bearer Token'</param>
        public static void AddBearerAuthentication(this SwaggerGenOptions options, string bearerAuthName = null, string description = null)
        {
            options.OperationFilter<SwaggerUniqueOperationIdFilter>();
            var scheme = new BearerScheme(
                !string.IsNullOrEmpty(bearerAuthName) ? bearerAuthName : "Bearer",
                !string.IsNullOrEmpty(description) ? description : "Bearer Token");
            options.DocumentFilter<SwaggerSecurityDocumentFilter>(scheme);
            options.OperationFilter<SwaggerSecurityOperationalFilter>(scheme);
        }

        /// <summary>
        /// https://swagger.io/docs/specification/authentication/oauth2/
        /// <para>OAuth 2.0 is an authorization protocol that gives an API client limited access to user data on a web server. OAuth relies on authentication scenarios called flows, which allow the resource owner (user) to share the protected content from the resource server without sharing their credentials. For that purpose, an OAuth 2.0 server issues access tokens that the client applications can use to access protected resources on behalf of the resource owner. For more information about OAuth 2.0, see oauth.net and RFC 6749.</para>
        /// <para>The flows (also called grant types) are scenarios an API client performs to get an access token from the authorization server. </para>
        /// <para>Authorization code – The most common flow, mostly used for server-side and mobile web applications. This flow is similar to how users sign up into a web application using their Facebook or Google account. </para>
        /// </summary>
        /// <param name="oauthName">Required. OAuth Name for scheme</param>
        /// <param name="details">Required. Authorization Grant Type Details (Auth Urls and Scope Definitions)</param>
        /// <param name="description">Optional. Describe the Auth or provide some instructions around the Auth Process</param>
        public static void AddOAuthAuthorizationAuthentication(this SwaggerGenOptions options, string oauthName, OAuthAuthorizationFlowDetail details, string description = null)
        {
            options.OperationFilter<SwaggerUniqueOperationIdFilter>();
            var scheme = new OAuthScheme(oauthName, OAuthGrantType.Authorization, details.ToOpenApiAuthFlow(), description);
            options.DocumentFilter<SwaggerSecurityDocumentFilter>(scheme);
            options.OperationFilter<SwaggerSecurityOperationalFilter>(scheme);
        }

        /// <summary>
        /// https://swagger.io/docs/specification/authentication/oauth2/
        /// <para>OAuth 2.0 is an authorization protocol that gives an API client limited access to user data on a web server. OAuth relies on authentication scenarios called flows, which allow the resource owner (user) to share the protected content from the resource server without sharing their credentials. For that purpose, an OAuth 2.0 server issues access tokens that the client applications can use to access protected resources on behalf of the resource owner. For more information about OAuth 2.0, see oauth.net and RFC 6749.</para>
        /// <para>The flows (also called grant types) are scenarios an API client performs to get an access token from the authorization server. </para>
        /// <para>Implicit – This flow requires the client to retrieve an access token directly. It is useful in cases when the user's credentials cannot be stored in the client code because they can be easily accessed by the third party. It is suitable for web, desktop, and mobile applications that do not include any server component.</para>
        /// </summary>
        /// <param name="oauthName">Required. OAuth Name for scheme</param>
        /// <param name="details">Required. Implicit Grant Type Details (Auth Urls and Scope Definitions)</param>
        /// <param name="description">Optional. Describe the Auth or provide some instructions around the Auth Process</param>
        public static void AddOAuthImplicitAuthentication(this SwaggerGenOptions options, string oauthName, OAuthImplicitFlowDetail details, string description = null)
        {
            options.OperationFilter<SwaggerUniqueOperationIdFilter>();
            var scheme = new OAuthScheme(oauthName, OAuthGrantType.Implicit, details.ToOpenApiAuthFlow(), description);
            options.DocumentFilter<SwaggerSecurityDocumentFilter>(scheme);
            options.OperationFilter<SwaggerSecurityOperationalFilter>(scheme);
        }

        /// <summary>
        /// https://swagger.io/docs/specification/authentication/oauth2/
        /// <para>OAuth 2.0 is an authorization protocol that gives an API client limited access to user data on a web server. OAuth relies on authentication scenarios called flows, which allow the resource owner (user) to share the protected content from the resource server without sharing their credentials. For that purpose, an OAuth 2.0 server issues access tokens that the client applications can use to access protected resources on behalf of the resource owner. For more information about OAuth 2.0, see oauth.net and RFC 6749.</para>
        /// <para>The flows (also called grant types) are scenarios an API client performs to get an access token from the authorization server. </para>
        /// <para>Password – Requires logging in with a username and password. Since in that case the credentials will be a part of the request, this flow is suitable only for trusted clients (for example, official applications released by the API provider).</para>
        /// </summary>
        /// <param name="oauthName"></param>
        /// <param name="details"></param>
        /// <param name="description"></param>
        public static void AddOAuthPasswordAuthentication(this SwaggerGenOptions options, string oauthName, OAuthPasswordFlowDetail details, string description = null)
        {
            options.OperationFilter<SwaggerUniqueOperationIdFilter>();
            var scheme = new OAuthScheme(oauthName, OAuthGrantType.Password, details.ToOpenApiAuthFlow(), description);
            options.DocumentFilter<SwaggerSecurityDocumentFilter>(scheme);
            options.OperationFilter<SwaggerSecurityOperationalFilter>(scheme);
        }

        /// <summary>
        /// https://swagger.io/docs/specification/authentication/oauth2/
        /// <para>OAuth 2.0 is an authorization protocol that gives an API client limited access to user data on a web server. OAuth relies on authentication scenarios called flows, which allow the resource owner (user) to share the protected content from the resource server without sharing their credentials. For that purpose, an OAuth 2.0 server issues access tokens that the client applications can use to access protected resources on behalf of the resource owner. For more information about OAuth 2.0, see oauth.net and RFC 6749.</para>
        /// <para>The flows (also called grant types) are scenarios an API client performs to get an access token from the authorization server. </para>
        /// <para>Client Credentials – Intended for the server-to-server authentication, this flow describes an approach when the client application acts on its own behalf rather than on behalf of any individual user. In most scenarios, this flow provides the means to allow users specify their credentials in the client application, so it can access the resources under the client’s control.</para>
        /// </summary>
        /// <param name="oauthName"></param>
        /// <param name="details"></param>
        /// <param name="description"></param>
        public static void AddOAuthClientCredentialsAuthentication(this SwaggerGenOptions options, string oauthName, OAuthClientCredentialsFlowDetail details, string description = null)
        {
            options.OperationFilter<SwaggerUniqueOperationIdFilter>();
            var scheme = new OAuthScheme(oauthName, OAuthGrantType.ClientCredentials, details.ToOpenApiAuthFlow(), description);
            options.DocumentFilter<SwaggerSecurityDocumentFilter>(scheme);
            options.OperationFilter<SwaggerSecurityOperationalFilter>(scheme);
        }
    }
}

namespace Hein.Swagger.Security
{
    public enum OAuthGrantType
    {
        /// <summary>
        /// Authorization Code flow (previously called accessCode in OpenAPI 2.0)
        /// </summary>
        Authorization,
        /// <summary>
        /// Implicit flow
        /// </summary>
        Implicit,
        /// <summary>
        /// Resource Owner Password flow
        /// </summary>
        Password,
        /// <summary>
        /// Client Credentials flow (previously called application in OpenAPI 2.0)
        /// </summary>
        ClientCredentials
    }
}

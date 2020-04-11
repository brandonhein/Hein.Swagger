﻿using Hein.Swagger.Attributes;
using Hein.Swagger.Filters;
using Hein.Swagger.Security.Keys;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Hein.Swagger
{
    public static class SwaggerGenOptionsExtensions
    {
        public static void EnforceQueryKey(this SwaggerGenOptions options, string queryName, string description = null)
        {
            options.OperationFilter<SwaggerUniqueOperationIdFilter>();
            var scheme = new QueryStringSecurityScheme(queryName.Replace("-", ""), description);
            options.DocumentFilter<SwaggerSecurityDocumentFilter>(scheme);
            options.OperationFilter<SwaggerSecurityOperationalFilter>(scheme);
        }

        public static void EnforceHeaderKey(this SwaggerGenOptions options, string headerName, string description = null)
        {
            options.OperationFilter<SwaggerUniqueOperationIdFilter>();
            var scheme = new HeaderSecurityScheme(headerName.Replace("-", ""), description);
            options.DocumentFilter<SwaggerSecurityDocumentFilter>(scheme);
            options.OperationFilter<SwaggerSecurityOperationalFilter>(scheme);
        }

        public static void EnforceCookieKey(this SwaggerGenOptions options, string cookieName, string description = null)
        {
            options.OperationFilter<SwaggerUniqueOperationIdFilter>();
            var scheme = new CookieSecurityScheme(cookieName.Replace("-", ""), description);
            options.DocumentFilter<SwaggerSecurityDocumentFilter>(scheme);
            options.OperationFilter<SwaggerSecurityOperationalFilter>(scheme);
        }

        public static void AddGithubRepository(this SwaggerGenOptions options, string githubRepositoryUrl)
        {
            options.OperationFilter<SwaggerUniqueOperationIdFilter>();
            options.DocumentFilter<GithubRepositoryDocumentFilter>(githubRepositoryUrl);
        }

        public static void DescribeStatusCodes(this SwaggerGenOptions options, params HttpStatusCode[] codes)
        {
            options.OperationFilter<SwaggerUniqueOperationIdFilter>();
            options.OperationFilter<SwaggerStatusCodeResponses>(codes);
        }

        public static void DescribeStandardStatusCodes(this SwaggerGenOptions options)
        {
            DescribeStatusCodes(options, HttpStatusCode.OK, HttpStatusCode.InternalServerError, HttpStatusCode.ServiceUnavailable);
        }

        public static void DescribeAllStatusCodes(this SwaggerGenOptions options)
        {
            options.OperationFilter<SwaggerUniqueOperationIdFilter>();
            var values = Enum.GetValues(typeof(HttpStatusCode)).Cast<HttpStatusCode>();
            DescribeStatusCodes(options, values.ToArray());
        }

        public static void DescribeRateLimitHeaders(this SwaggerGenOptions options)
        {
            options.OperationFilter<SwaggerUniqueOperationIdFilter>();
            options.OperationFilter<SwaggerRateLimitHeaders>();
        }

        public static void EnableControllerTags(this SwaggerGenOptions options)
        {
            options.OperationFilter<SwaggerUniqueOperationIdFilter>();
            options.OperationFilter<SwaggerControllerGroupTagOperationalFilter>();
        }

        public static void EnableDescriptionTags(this SwaggerGenOptions options)
        {
            options.OperationFilter<SwaggerUniqueOperationIdFilter>();
            options.OperationFilter<SwaggerDescriptionFilter>();

            //TODO ISSUE/FEATURE #1
            //options.DocumentFilter<SwaggerControllerDescriptionFilter>();
        }

        public static void EnableProducesHeaderTags(this SwaggerGenOptions options)
        {
            options.OperationFilter<SwaggerUniqueOperationIdFilter>();
            options.OperationFilter<SwaggerProducesHeadersFilter>();
        }

        public static void EnableSummaryTags(this SwaggerGenOptions options)
        {
            options.OperationFilter<SwaggerUniqueOperationIdFilter>();
            options.OperationFilter<SwaggerSummaryFilter>();
        }

        public static void EnableAnnotations(this SwaggerGenOptions options)
        {
            options.OperationFilter<SwaggerUniqueOperationIdFilter>();
            EnableControllerTags(options);
            EnableDescriptionTags(options);
            EnableSummaryTags(options);
            EnableProducesHeaderTags(options);
        }

        public static void EnableSwaggerVersioning(this SwaggerGenOptions options)
        {
            options.DocumentFilter<SwaggerVersionDocumentFilter>();

            options.DocInclusionPredicate((version, desc) =>
            {
                var versionsAttrs = desc.ControllerAttributes()
                    .OfType<SwaggerVersionAttribute>();

                if (versionsAttrs != null && versionsAttrs.Any())
                {
                    foreach (var versionAttr in versionsAttrs)
                    {
                        if (versionAttr.Version.Equals(version, StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                }

                return false;
            });
        }
    }
}

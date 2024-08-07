﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Formatters;
using Hein.Swagger.Security;
using Hein.Swagger.Filters;

namespace Hein.Swagger.Sample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            });

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info
                {
                    Title = "Hein.Swagger.Sample",
                    Version = "v1",
                    Description = "this is the description. [this is a link like github](https://github.com/brandonhein)"
                });

                x.AddGithubRepository("https://github.com/brandonhein/Hein.Swagger");
                //x.AddHeaderKey("x-api-key", "AWS API Gateway x-api-key");

                x.AddOAuthClientCredentialsAuthentication("Ping Federate", new OAuthClientCredentialsFlowDetail()
                {
                    TokenUrl = new System.Uri("https://auth")
                });

                x.EnableAnnotations();
                //x.EnableSwaggerVersioning();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseResponseTiming();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hein.Swagger.Sample - v1");

                c.EnableFilter();

                c.DisplayRequestDuration();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

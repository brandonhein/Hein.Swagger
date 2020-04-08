using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Formatters;
using Swashbuckle.AspNetCore.Swagger;
using System.Net;
using System.Collections.Generic;
using Hein.Swagger.Middleware;
using Microsoft.OpenApi.Models;

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

                x.SwaggerDoc("second", new Info
                {
                    Title = "Hein.Swagger.Sample",
                    Version = "second",
                    Description = "this is the description. [this is a link like github](https://github.com/brandonhein)"
                });

                x.AddGithubRepository("https://github.com/brandonhein/Hein.Swagger");
                x.EnforceHeaderKey("x-api-key", "AWS API Gateway x-api-key");

                x.EnableAnnotations();
                x.EnableSwaggerVersioning();

                x.DescribeAllEnumsAsStrings();
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

            app.UseLegacySwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hein.Swagger.Sample - v1");
                c.SwaggerEndpoint("/swagger/second/swagger.json", "Hein.Swagger.Sample - v2");

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

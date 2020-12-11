using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SGM.Auth.CrossCutting.DependencyInjection;
using SGM.Shared.Domain.Configure;

namespace SGM.Auth.Application
{
    public class Startup
    {
        private readonly string routePrefix;
        private readonly string prefixUrl;
        private readonly string basePath;        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
            routePrefix = configuration.GetSection("ConfigApp").GetSection("routePrefix").Value;
            prefixUrl = configuration.GetSection("ConfigApp").GetSection("prefixUrl").Value;
            basePath = "";

            if (!string.IsNullOrEmpty(this.prefixUrl))
            {
                string host = configuration.GetSection("ConfigApp").GetSection("swaggerHost").Value;
                string port = configuration.GetSection("ConfigApp").GetSection("swaggerHostPort").Value;
                basePath = $"http://{host}:{port}{prefixUrl}";
            }
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services, Configuration);
            ConfigureServicesJWT.ConfiureToken(services, Configuration);
            services.AddControllers();
            
            services.AddSwaggerDocumentation("SGM.Auth");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ConfigureSeed configureSeed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            configureSeed.Seed();

            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    swagger.Servers = new List<OpenApiServer> { new OpenApiServer { Url = string.IsNullOrEmpty(basePath) ? $"{httpReq.Scheme}://{httpReq.Host.Value}" : basePath } };
                });
            });

            app.UseSwaggerDocumentation("SGM.Auth v1.0", routePrefix, prefixUrl);
            
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using System;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SGM.Cidadao.CrossCutting.DependencyInjection;
using SGM.Cidadao.CrossCutting.Mappings;
using SGM.Shared.Domain.Configure;


namespace SGM.Cidadao.Application
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
            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services, Configuration);
            ConfigureServicesJWT.ConfiureToken(services, Configuration);
            ConfigureServicesSwagger.ConfigureSwagger(services, "SGM.Cidadao");
            
            
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                //cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
               // cfg.AddProfile(new ModelToEntityProfile());
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ConfigureSeed configureSeed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            configureSeed.Seed();
            app.UseRouting();
            app.UseSwagger();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sistema de Gestão Municipal (SGM.Cidadao)");
                c.RoutePrefix = "cidadao";
            });
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

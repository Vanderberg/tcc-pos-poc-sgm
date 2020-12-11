using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SGM.Shared.Domain.Configure
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, string title)
        {
            services.AddSwaggerGen(c => {
//                c.SwaggerDoc("v1", new OpenApiInfo { Title = title, Version = "v1.0" });
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Sistema de Gestão Municipal (" + title +")",
                    Description = "TCC - Arquitetura de Software Distribuído - PUC Minas Virtual",
                    TermsOfService = new Uri("https://github.com/Vanderberg/tcc-pos-poc-sgm"),
                    Contact = new OpenApiContact
                    {
                        Name = "Vanderberg Nunes",
                        Email = "teste@mail.com",

                    },
                    License = new OpenApiLicense
                    {
                        Name = "Termo de Licença de Uso",
                        Url = new Uri("https://github.com/Vanderberg/tcc-pos-poc-sgm")
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                });
                

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });

            });

            return services;

        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app, string title, string routePrefix, string prefixUrl)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                //"/swagger/v1/swagger.json"
                c.SwaggerEndpoint($"{prefixUrl}/swagger/v1/swagger.json", title);
                c.RoutePrefix = routePrefix;
                c.DocumentTitle = "Documentação";
                c.DocExpansion(DocExpansion.None);
            });

            return app;
        }
    }
    /*
    public class ConfigureServicesSwagger
    {
        public static void ConfigureSwagger(IServiceCollection services, string title)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Sistema de Gestão Municipal (" + title +")",
                    Description = "TCC - Arquitetura de Software Distribuído - PUC Minas Virtual",
                    TermsOfService = new Uri("https://github.com/Vanderberg/tcc-pos-poc-sgm"),
                    Contact = new OpenApiContact
                    {
                        Name = "Vanderberg Nunes",
                        Email = "teste@mail.com",

                    },
                    License = new OpenApiLicense
                    {
                        Name = "Termo de Licença de Uso",
                        Url = new Uri("https://github.com/Vanderberg/tcc-pos-poc-sgm")
                    }
                });
                
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Entre com o Token JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        }, new List<string>()
                    }
                });
            });
        }
    }*/
}
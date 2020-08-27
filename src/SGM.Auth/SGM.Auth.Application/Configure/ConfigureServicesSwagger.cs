using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SGM.Auth.Application.Configure
{
    public class ConfigureServicesSwagger
    {
        public static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Sistema de Gestão Municipal (SGM.Auth)",
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
    }
}
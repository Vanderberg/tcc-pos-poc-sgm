using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SGM.Cidadao.Application.Configure
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
                    Title = "Sistema de Gestão Municipal (SGM.Cidadao)",
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
    }
}
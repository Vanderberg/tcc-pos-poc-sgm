﻿using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SGM.Shared.Domain.Security;

namespace SGM.Shared.Domain.Configure
{
public class ConfigureServicesJWT
    {
        public static void ConfiureToken(IServiceCollection services, IConfiguration configuration)
        {
            var signingConfigurarions = new SigningConfigurations();
            services.AddSingleton(signingConfigurarions);

            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                configuration.GetSection("TokenConfigurations"))
                     .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);

            services.AddAuthentication(authOptions =>
             {
                 authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
             }).AddJwtBearer(bearerOptions =>
             {
                 var paramsValidation = bearerOptions.TokenValidationParameters;
                 paramsValidation.IssuerSigningKey = signingConfigurarions.Key;
                 paramsValidation.ValidAudience = tokenConfigurations.Audience;
                 paramsValidation.ValidIssuer = tokenConfigurations.Issuer;
                 paramsValidation.ValidateIssuer = true;
                 paramsValidation.ValidateAudience = true;

                 // Valida a assinatura de um token recebido
                 paramsValidation.ValidateIssuerSigningKey = true;

                 // Verifica se um token recebido ainda é válido
                 paramsValidation.ValidateLifetime = true;

                 // Tempo de tolerância para a expiração de um token (utilizado
                 // caso haja problemas de sincronismo de horário entre diferentes
                 // computadores envolvidos no processo de comunicação)
                 paramsValidation.ClockSkew = TimeSpan.Zero;
             });

             // Ativa o uso do token como forma de autorizar o acesso
             // a recursos deste projeto
             services.AddAuthorization(auth =>
             {
                 auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                     .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                     .RequireAuthenticatedUser().Build());
             });
        }
    }
}
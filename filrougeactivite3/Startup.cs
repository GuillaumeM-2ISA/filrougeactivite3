using API.Filters;
using BLLS;
using Domain;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZymLabs.NSwag.FluentValidation;

namespace API
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
            //JWT Authentication
            services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false, // Voulez-vous valider l'émmeteur
                    ValidateAudience = false, // Voulez-vous valider l'audience
                    ValidAudience = Configuration["JwtIssuer"],
                    ValidIssuer = Configuration["JwtIssuer"],
                    ValidateIssuerSigningKey = true, // Validation signature
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtKey"])),
                    //Retourne la différence de temps maximale autorisée entre le client et les paramètres de l'horloge du serveur.
                    ClockSkew = TimeSpan.Zero // remove delay of token when expire
                };
            });

            services.AddBLLExtension();
            services.AddDomain();
            services.AddFluentValidationAutoValidation();
            services.AddControllers(options =>
            {
                options.Filters.Add(new ApiExceptionFilterAttribute());
            });

            //Documentation Swagger
            services.AddOpenApiDocument((c, serviceProvider) =>
            {
                c.Title = "2isa Forum";
                c.DocumentName = "API";
                c.Description = "Mon API";
                c.Version = "V1";
                c.AddSecurity("Bearer", new OpenApiSecurityScheme()
                {
                    Description =
            "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Type = OpenApiSecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                c.AddSecurity(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Input your Bearer token to access this API",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Type = OpenApiSecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT",
                });
                c.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor());
                //c.OperationProcessors.Add(new SwaggerGlobalAuthProcessor());



                var fluentValidationSchemaProcessor = serviceProvider.CreateScope().ServiceProvider.GetService<FluentValidationSchemaProcessor>();



                // Add the fluent validations schema processor
                c.SchemaProcessors.Add(fluentValidationSchemaProcessor);
            });



            //FluentValidationDocumention RuleSet
            // Add the FluentValidationSchemaProcessor as a scoped service
            services.AddScoped<FluentValidationSchemaProcessor>(provider =>
            {
                var validationRules = provider.GetService<IEnumerable<FluentValidationRule>>();
                var loggerFactory = provider.GetService<ILoggerFactory>();



                return new FluentValidationSchemaProcessor(provider, validationRules, loggerFactory);
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Génération du json
            app.UseOpenApi();

            //Interface utilisateur de la documentation
            app.UseSwaggerUi3();

            app.UseRouting();

            //Add Authentication => code Erreur 401 
            app.UseAuthentication();

            //Authorization => Code Erreur 403 Forbidden
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

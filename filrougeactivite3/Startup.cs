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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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

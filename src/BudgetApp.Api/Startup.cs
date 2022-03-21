using BudgetApp.Api;
using BudgetApp.Infrastructure;
using BudgetApp.Infrastructure.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;

namespace BudgetApp
{
    public class Startup
    {
        private const string Bearer = "Bearer";
        private const string MongoSectionName = "Mongo";
        private const string AuthorizationSectionName = "Authorization";
        private const string GeneralSectionName = "GeneralSettings";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var authSettings = new AuthorizationSettings();
            Configuration.GetSection(AuthorizationSectionName).Bind(authSettings);

            services.Configure<GeneralSettings>(Configuration.GetSection(GeneralSectionName));

            services.AddControllers();
            // services.AddAuthentication(Bearer)
            //     .AddJwtBearer(Bearer, options =>
            //     {
            //         options.Authority = authSettings?.Authority;
            //         options.TokenValidationParameters = new TokenValidationParameters
            //         {
            //             ValidateAudience = false
            //         };
            //     });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BudgetApp", Version = "v1" });

                // c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                // {
                //     Type = SecuritySchemeType.OAuth2,
                //     Flows = new OpenApiOAuthFlows
                //     {
                //         ClientCredentials = new OpenApiOAuthFlow
                //         {
                //             AuthorizationUrl = new Uri(authSettings.AuthorizationUrl),
                //             TokenUrl = new Uri(authSettings.TokenEndpointUrl),
                //             Scopes = authSettings.Scopes
                //         }
                //     }
                // });
            });
            services.Configure<MongoDbSettings>(Configuration.GetSection(MongoSectionName));
            services.AddInfrastructure(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var mongoSettings = new MongoDbSettings();
            Configuration.GetSection(MongoSectionName).Bind(mongoSettings);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BudgetApp v1"));

            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;

                await context.Response.WriteAsJsonAsync(new { error = exception.Message });
            }));
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // app.MigrateDevSqlDb(env);
            // if (mongoSettings.SeedDatabase)
            // {
            //     MongoDbInitializer.Seed(mongoSettings);
            // }
        }
    }
}

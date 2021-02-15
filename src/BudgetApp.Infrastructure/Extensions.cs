using BudgetApp.Infrastructure.Sql;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace BudgetApp.Infrastructure
{
    public static class Extensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BudgetAppSql");

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddDbContextPool<BudgetAppContext>(options => options.UseSqlServer(connectionString));
        }

        public static void MigrateDevSqlDb(this IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                using var scope = app.ApplicationServices.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<BudgetAppContext>();
                db.Database.EnsureCreated();
            }
        }
    }
}

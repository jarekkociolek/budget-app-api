using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BudgetApp.Infrastructure
{
    public static class Extensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}

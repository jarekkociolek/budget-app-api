using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace BudgetApp.Infrastructure.Sql
{
    public class BudgetAppContext : DbContext
    {
        public BudgetAppContext([NotNull] DbContextOptions options)
            : base(options)
        {
        }
    }
}

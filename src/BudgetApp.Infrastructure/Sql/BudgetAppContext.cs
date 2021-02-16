using BudgetApp.Core.Entities;
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

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}

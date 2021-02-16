using BudgetApp.Core.Entities;
using BudgetApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BudgetApp.Infrastructure.Sql.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly BudgetAppContext _context;

        public ExpenseRepository(BudgetAppContext context)
        {
            _context = context;
        }

        public IEnumerable<Expense> GetAsync(Guid userId, Guid id)
        {
            return  _context.Expenses.Where(q => q.Id == id);
        }

        public Expense GetAsync(Guid id)
        {
            return _context.Expenses.FirstOrDefault(q => q.Id == id);
        }
    }
}

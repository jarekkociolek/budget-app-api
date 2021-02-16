using BudgetApp.Core.Entities;
using System;
using System.Collections.Generic;

namespace BudgetApp.Core.Repositories
{
    public interface IExpenseRepository
    {
        Expense GetAsync(Guid id);

        IEnumerable<Expense> GetAsync(Guid userId, Guid id);
    }
}

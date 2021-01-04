using BudgetApp.Core.Entities;
using System;
using System.Threading.Tasks;

namespace BudgetApp.Core.Repositories
{
    public interface IExpenseRepository
    {
        Task<Expense> GetAsync(Guid id);
    }
}

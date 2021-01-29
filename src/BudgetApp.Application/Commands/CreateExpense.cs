using BudgetApp.Application.DTO;
using MediatR;

namespace BudgetApp.Application.Commands
{
    public class CreateExpense : IRequest<bool>
    {
        public ExpenseDto ExpenseDto{ get; set; }
    }
}

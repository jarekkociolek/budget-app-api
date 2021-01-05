using BudgetApp.Application.DTO;
using MediatR;

namespace BudgetApp.Application.Queries.GetExpense
{
    public class GetExpense : IRequest<ExpenseDto>
    {
        public string ExpenseId { get; set; }
    }
}

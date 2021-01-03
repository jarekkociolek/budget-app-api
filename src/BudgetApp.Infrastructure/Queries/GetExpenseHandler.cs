using BudgetApp.Application.DTO;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetApp.Application.Queries.GetExpense
{
    public class GetExpenseHandler : IRequestHandler<GetExpense, ExpenseDto>
    {
        public Task<ExpenseDto> Handle(GetExpense request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ExpenseDto());
        }
    }
}

using BudgetApp.Application.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetApp.Infrastructure.Commands
{
    public class CreateExpenseHandler : IRequestHandler<CreateExpense, bool>
    {
        public Task<bool> Handle(CreateExpense request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

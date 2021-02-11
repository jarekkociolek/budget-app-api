using BudgetApp.Application.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetApp.Infrastructure.Commands
{
    public class RemoveExpenseHandler : IRequestHandler<RemoveExpense, bool>
    {
        public Task<bool> Handle(RemoveExpense request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

using MediatR;
using System;

namespace BudgetApp.Application.Commands
{
    public class RemoveExpense : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}

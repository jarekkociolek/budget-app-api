using MediatR;
using System;

namespace BudgetApp.Application.Commands
{
    public class RemoveCategory : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}

using BudgetApp.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;

namespace BudgetApp.Application.Queries
{
    public class GetExpenses : IRequest<IEnumerable<ExpenseDto>>
    {
        public Guid UserId { get; set; }
    }
}

using BudgetApp.Application.DTO;
using MediatR;
using System;

namespace BudgetApp.Application.Queries.GetExpense
{
    public class GetExpense : IRequest<ExpenseDto>
    {
        public Guid ExpenseId { get; set; }
    }
}

using BudgetApp.Application.DTO;
using MediatR;
using System.Collections.Generic;

namespace BudgetApp.Application.Queries
{
    public class GetExpenses : IRequest<ICollection<ExpenseDto>>
    {
        public string UserId { get; set; }
    }
}

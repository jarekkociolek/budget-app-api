using BudgetApp.Application.DTO;
using BudgetApp.Application.Queries.GetExpense;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BudgetApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpensesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ExpenseDto> Get(Guid expenseId)
        {
            return await _mediator.Send(new GetExpense { ExpenseId = expenseId} );
        }
    }
}

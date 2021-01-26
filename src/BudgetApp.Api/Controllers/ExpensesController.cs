using BudgetApp.Application.DTO;
using BudgetApp.Application.Queries;
using BudgetApp.Application.Queries.GetExpense;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ExpensesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpensesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<ExpenseDto>> Get(string userId, string expenseId)
        {
            var result = await _mediator.Send(new GetExpense { ExpenseId = expenseId} );

            if (result is null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ExpenseDto>>> Get(string userId)
        {
            var result = await _mediator.Send(new GetExpenses { UserId = userId });

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}

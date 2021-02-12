using BudgetApp.Application.Commands;
using BudgetApp.Application.DTO;
using BudgetApp.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> Get(Guid userId)
        {
            var result = await _mediator.Send(new GetCategories { UserId = userId });

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<ExpenseDto>> Delete(Guid id)
        {
            await _mediator.Send(new RemoveCategory { Id = id });
            return Ok();
        }
    }
}

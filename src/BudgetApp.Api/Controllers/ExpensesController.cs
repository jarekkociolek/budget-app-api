using BudgetApp.Application.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BudgetApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpensesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<ExpenseDto> Get()
        {
            throw new NotImplementedException();
        }

    }
}

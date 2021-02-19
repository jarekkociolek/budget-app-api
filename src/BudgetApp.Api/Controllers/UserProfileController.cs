using BudgetApp.Application.Commands.UserProfile;
using BudgetApp.Application.Queries.UserProfile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string subject)
        {
            return Ok(await _mediator.Send(new GetUserProfile { Id = subject }));
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var subject = User.Claims.FirstOrDefault(c => c.Type == "sub").Value;

            await _mediator.Send(new CreateUserProfile { Subject = subject });
            return Ok();
        }
    }
}

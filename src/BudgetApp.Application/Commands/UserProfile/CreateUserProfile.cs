using MediatR;

namespace BudgetApp.Application.Commands.UserProfile
{
    public class CreateUserProfile : IRequest
    {
        public string Subject { get; set; }
    }
}

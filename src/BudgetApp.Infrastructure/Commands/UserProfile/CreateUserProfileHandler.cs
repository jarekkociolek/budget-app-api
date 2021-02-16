using BudgetApp.Application.Commands.UserProfile;
using BudgetApp.Core.Entities;
using BudgetApp.Infrastructure.Sql;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetApp.Infrastructure.Commands.UserProfile
{
    public class CreateUserProfileHandler : IRequestHandler<CreateUserProfile>
    {
        private readonly BudgetAppContext _context;

        public CreateUserProfileHandler(BudgetAppContext context)
        {
            _context = context;   
        }

        public async Task<Unit> Handle(CreateUserProfile request, CancellationToken cancellationToken)
        {
            var userProfile = new User
            {
                Subject = request.Subject
            };

            _ = await _context.Users.AddAsync(userProfile);
            await _context.SaveChangesAsync();

            return await Unit.Task;
        }
    }
}

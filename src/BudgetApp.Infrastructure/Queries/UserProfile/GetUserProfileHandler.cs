using BudgetApp.Application.Queries.UserProfile;
using BudgetApp.Core.Entities;
using BudgetApp.Infrastructure.Sql;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetApp.Infrastructure.Queries.UserProfile
{
    public class GetUserProfileHandler : IRequestHandler<GetUserProfile, User>
    {
        private readonly BudgetAppContext _context;

        public GetUserProfileHandler(BudgetAppContext context)
        {
            _context = context;
        }

        public Task<User> Handle(GetUserProfile request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_context.Users.FirstOrDefault(q => q.Subject == request.Id));
        }
    }
}

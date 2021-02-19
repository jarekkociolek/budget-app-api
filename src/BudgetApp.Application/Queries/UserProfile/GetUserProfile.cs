using MediatR;
using System;
using BudgetApp.Core.Entities;

namespace BudgetApp.Application.Queries.UserProfile
{
    public class GetUserProfile : IRequest<User>
    {
        public string Id { get; set; }
    }
}

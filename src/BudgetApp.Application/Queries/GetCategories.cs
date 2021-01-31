using BudgetApp.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;

namespace BudgetApp.Application.Queries
{
    public class GetCategories : IRequest<IEnumerable<CategoryDto>>
    {
        public Guid UserId { get; set; }
    }
}

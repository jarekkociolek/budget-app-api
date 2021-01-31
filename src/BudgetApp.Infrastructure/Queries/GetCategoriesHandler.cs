using BudgetApp.Application.DTO;
using BudgetApp.Application.Queries;
using BudgetApp.Infrastructure.Mongo.Documents;
using BudgetApp.Infrastructure.Settings;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetApp.Infrastructure.Queries
{
    class GetCategoriesHandler : IRequestHandler<GetCategories, IEnumerable<CategoryDto>>
    {
        private readonly IMongoCollection<UserDocument> _users;

        public GetCategoriesHandler(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);

            _users = database.GetCollection<UserDocument>(settings.Value.ExpensesCollectionName);
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetCategories request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}


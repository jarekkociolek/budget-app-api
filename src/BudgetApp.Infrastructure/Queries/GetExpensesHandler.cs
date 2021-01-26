using BudgetApp.Application.DTO;
using BudgetApp.Application.Queries;
using BudgetApp.Infrastructure.Mongo.Documents;
using BudgetApp.Infrastructure.Settings;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetApp.Infrastructure.Queries
{
    public class GetExpensesHandler : IRequestHandler<GetExpenses, IEnumerable<ExpenseDto>>
    {
        private readonly IMongoCollection<ExpenseDocument> _expenses;

        public GetExpensesHandler(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);

            _expenses = database.GetCollection<ExpenseDocument>(settings.Value.ExpensesCollectionName);
        }

        public async Task<IEnumerable<ExpenseDto>> Handle(GetExpenses request, CancellationToken cancellationToken)
        {
            var documents = await _expenses.Find(q => q.UserId == request.UserId)
                .ToListAsync();

            if (documents is null)
            {
                return null;
            }

            return documents.Select(q => new ExpenseDto { Name = q.Name, Category = q.Category, Value = q.Value });
        }
    }
}

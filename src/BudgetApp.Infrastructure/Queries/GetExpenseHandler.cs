using BudgetApp.Application.DTO;
using BudgetApp.Infrastructure.Mongo.Documents;
using BudgetApp.Infrastructure.Settings;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetApp.Application.Queries.GetExpense
{
    public class GetExpenseHandler : IRequestHandler<GetExpense, ExpenseDto>
    {
        private readonly IMongoCollection<ExpenseDocument> _expenses;

        public GetExpenseHandler(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);

            _expenses = database.GetCollection<ExpenseDocument>(settings.Value.ExpensesCollectionName);
        }

        public async Task<ExpenseDto> Handle(GetExpense request, CancellationToken cancellationToken)
        {
            var document = await _expenses.Find(q => q.Id == request.ExpenseId.ToString())
                .SingleOrDefaultAsync();

            return new ExpenseDto
            {
                Name = document.Name,
                Category = document.Category,
                Value = document.Value
            };
        }
    }
}

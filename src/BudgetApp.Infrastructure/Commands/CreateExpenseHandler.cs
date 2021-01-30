using BudgetApp.Application.Commands;
using BudgetApp.Infrastructure.Mongo.Documents;
using BudgetApp.Infrastructure.Settings;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetApp.Infrastructure.Commands
{
    public class CreateExpenseHandler : IRequestHandler<CreateExpense, bool>
    {
        private readonly IMongoCollection<ExpenseDocument> _expenses;

        public CreateExpenseHandler(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);

            _expenses = database.GetCollection<ExpenseDocument>(settings.Value.ExpensesCollectionName);
        }

        public async Task<bool> Handle(CreateExpense request, CancellationToken cancellationToken)
        {
            var expenseDocument = new ExpenseDocument
            {
                Category = request.ExpenseDto.Category,
                Name = request.ExpenseDto.Name,
                Value = request.ExpenseDto.Value,
                UserId = request.ExpenseDto.UserId,
            };

            await _expenses.InsertOneAsync(expenseDocument);

            return true;
        }
    }
}

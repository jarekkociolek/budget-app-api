using System;

namespace BudgetApp.Infrastructure.Mongo.Documents
{
    internal sealed class ExpenseDocument : BaseDocument
    {
        public decimal Value { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}

using System;

namespace BudgetApp.Core.Entities
{
    public class Expense
    {
        public Guid Id { get; }
        public decimal Value { get; }
        public string Category { get; }
        public string Name { get; }

        public Expense(string name, decimal value, string category)
        {
            Name = name;
            Value = value;
            Category = category;
        }
    }
}

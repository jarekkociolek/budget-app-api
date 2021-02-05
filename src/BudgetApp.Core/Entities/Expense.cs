using System;

namespace BudgetApp.Core.Entities
{
    public class Expense
    {
        public Guid Id { get; }
        public Money Amount { get; }
        public Category Category { get; }
        public string Name { get; }

        public Expense(string name, Money amount, Category category)
        {
            Name = name;
            Amount = amount;
            Category = category;
        }
    }
}

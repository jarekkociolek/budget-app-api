using System.Collections.Generic;

namespace BudgetApp.Core
{
    public class Money : ValueObject
    {
        public decimal Value { get; private set; }
        public Currency Currency { get; private set; }

        public Money(decimal value, Currency currency)
        {
            Value = value;
            Currency = currency;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Currency;
        }
    }
}

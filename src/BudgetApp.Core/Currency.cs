using System.Collections.Generic;

namespace BudgetApp.Core
{
    public class Currency : ValueObject
    {
        public string Name { get; private set; }
        public string Symbol { get; private set; }

        public Currency(string name, string symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Symbol;
        }
    }
}

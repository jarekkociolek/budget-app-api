using System.Collections.Generic;

namespace BudgetApp.Core.Entities
{
    public class User
    {
        public string Id { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}

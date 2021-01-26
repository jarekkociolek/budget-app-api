using System.Collections.Generic;

namespace BudgetApp.Core.Entities
{
    public class User
    {
        public string Id { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}

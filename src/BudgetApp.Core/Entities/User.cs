using System;
using System.Collections.Generic;

namespace BudgetApp.Core.Entities
{
    public class User
    {
        private ISet<Category> _categories = new HashSet<Category>();

        public Guid Id { get; set; }

        public string Subject { get; set; }

        public ISet<Category> Categories => _categories;
    }
}

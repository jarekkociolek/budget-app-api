using System.Collections.Generic;

namespace BudgetApp.Core.Entities
{
    public class User
    {
        private ISet<Category> _categories = new HashSet<Category>();

        public string Id { get; set; }
        public ISet<Category> Categories => _categories;

        public void AddCategory(Category category)
        {
            _categories.Add(category);
        }

        public void RemoveCategory(Category category)
        {
            _categories.Remove(category);
        }
    }
}

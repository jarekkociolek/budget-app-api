using System;

namespace BudgetApp.Core.Entities
{
    public class Category
    {
        public Guid Id { get; }

        public string Name { get; private set; }

        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public void ChangeCategoryName(string name)
        {
            if(!string.IsNullOrEmpty(name))
            {
                Name = name;
            }
        }
    }
}

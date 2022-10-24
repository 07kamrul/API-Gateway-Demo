using Catalog.Models;

namespace Catalog.Services
{
    public class CatalogService : ICatalogService
    {
        public List<Category> FindAll()
        {
            return new List<Category>
            {
                new Category { Id = "C1", Name = "Category 1"},
                new Category { Id = "C2", Name = "Category 2"},
                new Category { Id = "C3", Name = "Category 3"},
                new Category { Id = "C4", Name = "Category 4"}
            };
        }
    }
}

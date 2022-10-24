using Catalog.Models;

namespace Catalog.Services
{
    public interface ICatalogService
    {
        List<Category> FindAll();
    }
}

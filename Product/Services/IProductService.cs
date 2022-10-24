using Product.Models;

namespace Product.Services
{
    public interface IProductService
    {
        List<ProductModel> FindAll();
    }
}

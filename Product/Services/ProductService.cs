using Product.Models;

namespace Product.Services
{
    public class ProductService : IProductService
    {
        public List<ProductModel> FindAll()
        {
            return new List<ProductModel>
            {
                new ProductModel { Id = 1, Name = "Rice", Price = 85.5},
                new ProductModel { Id = 2, Name = "Milk", Price = 40.0},
                new ProductModel { Id = 3, Name = "Egg", Price = 150.0},
                new ProductModel { Id = 4, Name = "Daal", Price = 85.5}
            };
        }
    }
}

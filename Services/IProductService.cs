using ProductManagementAPI.Models;

namespace ProductManagementAPI.Services;

public interface IProductService
{
    Task<List<Product>> GetAllProducts();
    Task<Product> GetProductById(int productId);
    Task<Product> CreateProduct(Product product);
    Task<Product> UpdateProduct(int productId, Product product);
    Task<bool> DeleteProduct(int productId);
}
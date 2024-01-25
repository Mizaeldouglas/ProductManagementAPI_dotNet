using ProductManagementAPI.Models;

namespace ProductManagementAPI.Services;

public class ProductService : IProductService
{
    public Task<Product> CreateProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProduct(int productId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProductById(int productId)
    {
        throw new NotImplementedException();
    }

    public Task<Product> UpdateProduct(int productId, Product product)
    {
        throw new NotImplementedException();
    }
}
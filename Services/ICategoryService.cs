using ProductManagementAPI.Models;

namespace ProductManagementAPI.Services;

public interface ICategoryService
{
    Task<List<Category>> GetAllCategories();
    Task<Category> GetCategoryById(int categoryId);
    Task<Category> CreateCategory(Category category);
    Task<Category> UpdateCategory(int categoryId, Category category);
    Task<bool> DeleteCategory(int categoryId);
}
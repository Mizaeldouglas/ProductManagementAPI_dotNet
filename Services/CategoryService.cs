using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Data;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.Services;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task<Category> CreateCategory(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }
    [HttpDelete("categoryId")]
    public async Task<bool> DeleteCategory(int categoryId)
    {
        var category = await _context.Categories.FindAsync(categoryId);

        if (category == null)
        {
            return false;
        }

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Category>> GetAllCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> GetCategoryById(int categoryId)
    {
        return await _context.Categories.FindAsync(categoryId);
    }

    public async Task<Category> UpdateCategory(int categoryId, Category category)
    {
        var existingCategory = await _context.Categories.FindAsync(categoryId);
        if (existingCategory == null)
        {
            return null;
        }
        existingCategory.Name = category.Name;
        await _context.SaveChangesAsync();
        return existingCategory;
    }
}
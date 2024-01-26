
using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Data;
using ProductManagementAPI.Models;
using ProductManagementAPI.Services;

namespace ProductManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService, ApplicationDbContext context)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllGategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        public async Task<ActionResult<Category>> GetCategoryById(int categoryId)
        {
            var category = await _categoryService.GetCategoryById(categoryId);

            if (category == null) 
                return NotFound();
            
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            var createdCategory = await _categoryService.CreateCategory(category);
            return CreatedAtAction(nameof(GetCategoryById), new { categoryId = createdCategory.CategoryId },
                createdCategory);
        }

        [HttpPut("{categoryId}")]
        public async Task<ActionResult<Category>> UpdateCategory(int categoryId, Category category)
        {
            var updatedCategory = await _categoryService.UpdateCategory(categoryId, category);
            if (updatedCategory == null)
            {
                return NotFound();
            }

            return Ok(updatedCategory);
        }
        [HttpDelete("{categoryId}")]
        public async Task<ActionResult<bool>> DeleteCategory(int categoryId)
        {
            var result = await _categoryService.DeleteCategory(categoryId);

            if (!result)
            {
                return NotFound();
            }

            return Ok(true);
        }
        
    }
}
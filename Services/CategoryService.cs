using System.Collections.Generic;
using ViktorWatches.Data;
using ViktorWatches.Domain;
using System.Linq;
using ViktorWatches.Abstraction;

namespace ViktorWatches.Services
{

    public class CategoryService : ICategoryService 
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.Find(categoryId);
        }
        public List<Category> GetCategories()
        {
            List<Category> categories = _context.Categories.ToList();
            return categories;
        }
        public List<Watch> GetWatchesByCategory(int categoryId)
        {
            return _context.Watches
                .Where(x => x.CategoryId == categoryId)
                .ToList();
        }

        public List<Watch> GetWatchesBycategory(int categoryId)
        {
            throw new System.NotImplementedException();
        }
    }
}

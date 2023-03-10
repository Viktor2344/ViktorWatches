using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViktorWatches.Domain;

namespace ViktorWatches.Abstraction
{
    interface ICategoryService
    {
        List<Category> GetCategories();

        Category GetCategoryById(int categoryId);

        List<Watch> GetWatchesBycategory(int categoryId);
    }
}

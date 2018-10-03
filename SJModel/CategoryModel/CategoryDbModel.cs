using SJModel.Core;
using SJModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJModel.CategoryModel
{
    public class CategoryDbModel : BaseModel
    {
        public CategoryDbModel(MainContainer DB) : base(DB) { }
        public CategoryDbModel(IDatabaseFactory iFactory) : base(iFactory) { }

        public void SaveCategory(Category category)
        {

            if (category == null)
                return;

            DB.Categories.Add(category);
            DB.SaveChanges();

        }
        public List<Category> GetAllCategoryFromDB()
        {
            List<Category> allCategory = new List<Category>();
            allCategory = DB.Categories.Where(x => x.IsActive != null && x.IsActive.Value).ToList();
            if (allCategory != null && allCategory.Count > 0)
            {
                allCategory = allCategory.OrderBy(x => x.CategoryOrder).ToList();
            }
            return allCategory;
        }


        public void UpdateCategory(Category category)
        {

            if (category == null)
                return;
            var categeryFromDb= DB.Categories.FirstOrDefault(x => x.ProductCategoryId == category.ProductCategoryId);

            categeryFromDb.ProductCategoryName = category.ProductCategoryName;
            categeryFromDb.CategoryOrder = category.CategoryOrder;
            categeryFromDb.Content = category.Content;

            DB.SaveChanges();

        }

        public Category GetCategoryById(int categoryId)
        {
            if (categoryId == 0)
                return null;

            var category = DB.Categories.FirstOrDefault(x => x.ProductCategoryId == categoryId && x.IsActive != null && x.IsActive.Value);
            return category;
        }
        public void DeleteCategory(int categoryId)
        {
            if (categoryId == 0)
                return;
            Category category = DB.Categories.FirstOrDefault(x => x.ProductCategoryId == categoryId);
            if (category != null)
            {
                category.IsActive = false;
                DB.SaveChanges();
            }
        }



    }
}

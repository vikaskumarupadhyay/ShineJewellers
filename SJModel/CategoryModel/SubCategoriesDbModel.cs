using SJModel.Core;
using SJModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJModel.CategoryModel
{
    public class SubCategoriesDbModel : BaseModel
    {

        public SubCategoriesDbModel(MainContainer DB) : base(DB) { }
        public SubCategoriesDbModel(IDatabaseFactory iFactory) : base(iFactory) { }

        public void SaveSubCategory(SubCategory subCategory)
        {

            if (subCategory == null)
                return;

            DB.SubCategories.Add(subCategory);
            DB.SaveChanges();

        }
        public List<SubCategory> GetAllSubCategoryFromDB()
        {
            List<SubCategory> allSubCategory = new List<SubCategory>();
            allSubCategory = DB.SubCategories.Where(x => x.IsActive != null && x.IsActive.Value).ToList();
            if (allSubCategory != null && allSubCategory.Count > 0)
            {
                allSubCategory = allSubCategory.OrderBy(x => x.SubCategoryOrder).ToList();
            }
            return allSubCategory;
        }

        public SubCategoryCollection GetSubCategoryCollection()
        {
            SubCategoryCollection subCategoryCollection = new SubCategoryCollection();

            List<SubCategory> allSubCategory = new List<SubCategory>();
            allSubCategory = DB.SubCategories.Where(x => x.IsActive != null && x.IsActive.Value).ToList();
            if (allSubCategory != null && allSubCategory.Count > 0)
            {
                allSubCategory = allSubCategory.OrderBy(x => x.SubCategoryOrder).ToList();
                subCategoryCollection.SubCategories = allSubCategory;
            }

            List<Category> allCategory = new CategoryDbModel(DB).GetAllCategoryFromDB();

            if (allCategory != null && allCategory.Count > 0)
            {
                subCategoryCollection.Categories = (from st in allCategory
                                              select new CategoryDetail
                                              {
                                                  CategoryId = st.ProductCategoryId,
                                                  CategoryName = st.ProductCategoryName
                                              }).ToList();
            }
            return subCategoryCollection;

        }
        public void UpdateSubCategory(SubCategory subCategory)
        {

            if (subCategory == null)
                return;
            var subCategoryFromDb = DB.SubCategories.FirstOrDefault(x => x.SubCategoryId == subCategory.SubCategoryId);

            subCategoryFromDb.SubCategoryName = subCategory.SubCategoryName;
            subCategoryFromDb.SubCategoryOrder = subCategory.SubCategoryOrder;
            subCategoryFromDb.Content = subCategory.Content;
            subCategoryFromDb.ProductCategoryId = subCategory.ProductCategoryId;

            DB.SaveChanges();

        }

        public SubCategory GetSubCategoryById(int subCategoryId)
        {
            if (subCategoryId == 0)
                return null;

            var subCategory = DB.SubCategories.FirstOrDefault(x => x.SubCategoryId == subCategoryId && x.IsActive != null && x.IsActive.Value);
            return subCategory;
        }

        public void DeleteSubCategory(int subCategoryId)
        {
            if (subCategoryId == 0)
                return;
            SubCategory subCategory = DB.SubCategories.FirstOrDefault(x => x.SubCategoryId == subCategoryId);
            if (subCategory != null)
            {
                subCategory.IsActive = false;
                DB.SaveChanges();
            }
        }

        public SubCategoryItem GetSubCategoryItem(int subCategoryId)
        {
            if (subCategoryId == 0)
                return null;

            SubCategoryItem subCategoryItem = (from cat in DB.Categories
                                               join
                                           subCat in DB.SubCategories on
                                              cat.ProductCategoryId equals subCat.ProductCategoryId
                                               where subCat.SubCategoryId == subCategoryId && 
                                               subCat.IsActive!=null && subCat.IsActive.Value 
                                               select new SubCategoryItem
                                               {
                                                   MainCategoryId = subCat.ProductCategoryId,
                                                   MainCategoryName = cat.ProductCategoryName,
                                                   SubCategoryContent = subCat.Content,
                                                   SubCategoryId = subCat.SubCategoryId,
                                                   SubCategoryName = subCat.SubCategoryName,
                                                   SubCategoryOrder = subCat.SubCategoryOrder
                                               }).FirstOrDefault();

            return subCategoryItem;
        }
    }
}

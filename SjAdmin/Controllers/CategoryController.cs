
using SJModel.CategoryModel;
using SJModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SjAdmin.Controllers
{
    public class CategoryController : BaseController
    {
        #region Category Actions

        public ActionResult CreateMainMenu()
        {
            List<Category> categoryCollection = CategoryDbModel.GetAllCategoryFromDB();
            return View("Category",categoryCollection);
        }
        public JsonResult SaveCategory(Category category)
        {
            string message = "";
            bool savedSuccessfully = true;
            try
            {
                if (category != null)
                {
                    if (category.ProductCategoryId > 0)
                    {
                        CategoryDbModel.UpdateCategory(category);
                        message = "Category updated successfully";
                    }
                    else
                    {
                        CategoryDbModel.SaveCategory(category);
                        message = "Category created successfully";
                    }
                }
                else
                {
                    message = "Kindly provide valid information, contact to application admin";
                    savedSuccessfully = false;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                savedSuccessfully = false;
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }
            return Json(new { SaveMessage = message,IsSuccess= savedSuccessfully });
        }

        public ActionResult GetCategoryInformation(int categoryId)
        {
            Category category= CategoryDbModel.GetCategoryById(categoryId);
            return Json(new { CategoryDetail = category }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCategory(int categoryId)
        {
            string message = "Category deleted successfuly";
            try
            {
                CategoryDbModel.DeleteCategory(categoryId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }

            return Json(new { DeleteMessage = message });
        }

        #endregion


        #region Sub Category Actions
        public ActionResult CreateSubMenu()
        {
            SubCategoryCollection subCategoryCollection = SubCategoryDbModel.GetSubCategoryCollection();
            return View("SubCategory", subCategoryCollection);
        }
        public JsonResult SaveSubCategory(SubCategory subCategory)
        {
            string message = "";
            bool savedSuccessfully = true;
            try
            {
                if (subCategory != null)
                {
                    if (subCategory.SubCategoryId > 0)
                    {
                        SubCategoryDbModel.UpdateSubCategory(subCategory);
                        message = "Sub Category updated successfully";
                    }
                    else
                    {
                        SubCategoryDbModel.SaveSubCategory(subCategory);
                        message = "Sub Category created successfully";
                    }
                }
                else
                {
                    message = "Kindly provide valid information, contact to application admin";
                    savedSuccessfully = false;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                savedSuccessfully = false;
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }
            return Json(new { SaveMessage = message, IsSuccess = savedSuccessfully });
        }

        public JsonResult GetSubCategoryDetail(int subCategoryId)
        {
            SubCategoryItem subCategoryViewModel = new SubCategoryItem();
            try
            {
                subCategoryViewModel = SubCategoryDbModel.GetSubCategoryItem(subCategoryId);
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }
            return Json(subCategoryViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteSubCategory(int subCategoryId)
        {
            string message = "Sub category deleted successfuly";
            try
            {
                SubCategoryDbModel.DeleteSubCategory(subCategoryId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }

            return Json(new { DeleteMessage = message });
        }


        #endregion
    }
}

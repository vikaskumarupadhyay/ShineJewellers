using SjAdmin.Models;
using SjAdmin.Models.ViewModel.Product;
using SJModel.Data;
using SJModel.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SjAdmin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        ProductHelper helper = new Models.ProductHelper();
        public ActionResult Index()
        {
              List <Stone> stones= StoneDbModel.GetAllStonesFromDB();
            List<Finding> findings = FindingDbModel.GetAllFindingsFromDB();
            List<Category> categories = CategoryDbModel.GetAllCategoryFromDB();
            ProductItem item = new ProductItem();
            item.Stones = stones;
            item.Findings = findings;
            item.Categories = categories;

            return View(item);
        }
        public ActionResult GetSubCategory(int productCategoryId)
        {
            List<SubCategory> categoryCollection = SubCategoryDbModel.GetAllSubCategoryFromDBForSpecificCategoryId(productCategoryId);
            return Json(new { html = ViewRenderer.RenderPartialToString(this.ControllerContext, "SubCategories", new ViewDataDictionary(categoryCollection), new TempDataDictionary())},JsonRequestBehavior.AllowGet);

            //return View("SubCategories",categoryCollection);
        }

        public ActionResult Test()
        {
            return View();
        }

        #region Finding Action Methods
        public ActionResult Finding()
        {
            var allFindings = FindingDbModel.GetAllFindingsFromDB();
            ProductFindingViewModel productFindingViewModel = helper.ConvertFindingToViewModel(allFindings);
            return View(productFindingViewModel);

            
        }

        public JsonResult GetFindingDetail(int findingId)
        {
         Finding finding=  FindingDbModel.GetFindingModel(findingId);
            ProductFinding viewModelFinding= helper.GetViewModelProductFindingFromDbFinding(finding);
            return Json(viewModelFinding, JsonRequestBehavior.AllowGet);
        }
        

        public JsonResult SaveFinding(Finding finding)
        {
            string message = "";
            try
            {
                if (finding != null)
                {
                    if (finding.FindingId > 0)
                    {
                        message = "Finding updated successfully";
                        FindingDbModel.UpdateFinding(finding);
                    }
                    else
                    {
                        message = "Finding created successfully";
                        FindingDbModel.SaveFinding(finding);
                    }
                }
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                message = "Finding updation failed : " + ex.Message;
            }
            return Json(new { UpdateMessage = message });
        }


        public JsonResult DeleteFinding(int findingId)
        {
            string message = "Finding deleted successfuly";
            try
            {
                FindingDbModel.DeleteFinding(findingId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }

            return Json(new { DeleteMessage = message });
        }

        #endregion


        public ActionResult DisplayAllStone()
        {
            var allStoneFromDb = StoneDbModel.GetAllStonesFromDB();
            List<StoneViewModel> stoneViewModelCollection = helper.GetViewModelFromDbStoneCollection(allStoneFromDb);
            return View("Stone", stoneViewModelCollection);
        }

        public JsonResult SaveStone(StoneViewModel stoneViewModel)
        {
            string message = "";
            try
            {
                if (stoneViewModel != null)
                {
                    Stone stone = helper.GetStoneObjectFromViewModelStone(stoneViewModel);
                    if (stone != null)
                    {
                        if (stone.StoneId > 0)
                        {
                            message = "Stone details updated successfully";
                             StoneDbModel.UpdateStone(stone);
                        }
                        else
                        {
                            message = "Stone created successfully";
                            StoneDbModel.SaveStone(stone);
                        }
                    }
                    else
                    {
                        message = "Application was not able to create Stone, contact Admin";
                    }
                }
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                message =ex.Message;
            }
            return Json(new { UpdateMessage = message });
        }

        public JsonResult GetStoneDetail(int stoneId)
        {
            Stone stone = StoneDbModel.GetStoneModel(stoneId);
            StoneViewModel stoneviewModel = helper.GetViewModelFromDbStone(stone);
            return Json(stoneviewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteStone(int stoneId)
        {
            string message = "Stone deleted successfuly";
            try
            {
                StoneDbModel.DeleteStone(stoneId);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
            }

            return Json(new { DeleteMessage = message });
        }

    }
}
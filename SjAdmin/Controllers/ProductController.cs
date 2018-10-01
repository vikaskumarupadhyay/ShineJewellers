using SjAdmin.Models;
using SjAdmin.Models.ViewModel.Product;
using SJModel.Data;
using SJModel.Product;
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
            return View();
        }


        public ActionResult Test()
        {
            return View();
        }

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
    }
}
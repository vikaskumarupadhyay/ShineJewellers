using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SjAdmin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Category
        public ActionResult CreateMainMenu()
        {
            return View("Category");
        }
    }
}
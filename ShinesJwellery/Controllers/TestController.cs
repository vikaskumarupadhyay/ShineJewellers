using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShinesJwellery.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            //SJModel.TestTableModel ds = new SJModel.TestTableModel();
              //  ds.SaveTestTable();
            return View();
        }
    }
}
using SJModel.Data;
using SJModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SjAdmin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        #region Models
        private MainContainer _db;
        public MainContainer DB
        {
            get
            {
                return _db ?? (_db = new MainContainer());
            }
        }

        private FindingDbModel _findingDbModel { get; set; }

        protected FindingDbModel FindingDbModel
        {
            get
            {
                return _findingDbModel ?? (_findingDbModel = new FindingDbModel(DB));
            }
        }
        #endregion
    }
}
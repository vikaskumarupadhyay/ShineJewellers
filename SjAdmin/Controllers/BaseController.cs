using SJModel.CategoryModel;
using SJModel.Data;
using SJModel.ProductModel;
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

        private StoneDbModel _stoneDbModel { get; set; }

        protected StoneDbModel StoneDbModel
        {
            get
            {
                return _stoneDbModel ?? (_stoneDbModel = new StoneDbModel(DB));
            }
        }

        private CategoryDbModel _categoryDbModel { get; set; }

        protected CategoryDbModel CategoryDbModel
        {
            get
            {
                return _categoryDbModel ?? (_categoryDbModel = new CategoryDbModel(DB));
            }
        }

        

        #endregion
    }
}
using SJModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJModel.CategoryModel
{
    public class SubCategoryItem
    {

        public int SubCategoryId { get; set; }

        public string SubCategoryName { get; set; }

        public int SubCategoryOrder { get; set; }
        public string SubCategoryContent { get; set; }
        public string MainCategoryName { get; set; }
        public int MainCategoryId { get; set; }

    }
    public class CategoryDetail
    {
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
    }

    public class SubCategoryCollection
    {

        public List<CategoryDetail> Categories { get; set; }
        public List<SubCategory> SubCategories { get; set; }


    }

}

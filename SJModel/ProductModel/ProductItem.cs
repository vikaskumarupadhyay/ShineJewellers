using SJModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJModel.ProductModel
{
  public  class ProductItem
    {
        public List<Stone> Stones { get; set; }

        public List<Finding> Findings { get; set; }

        public List<Category> Categories { get; set; }


    }
}

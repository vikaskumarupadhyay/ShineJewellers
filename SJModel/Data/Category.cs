using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJModel.Data
{
    [Table("ProductCategory")]
    public partial class Category
    {
        [Key]
        public int ProductCategoryId { get; set; }

        public string ProductCategoryName { get; set; }
        public bool? IsActive { get; set; }
        public int CategoryOrder { get; set; }

        public string Content { get; set; }
        public string RouteControllerName { get; set; }
        public string RouteActionName { get; set; }

    }
}

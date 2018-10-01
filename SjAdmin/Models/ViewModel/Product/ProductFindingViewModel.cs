using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SjAdmin.Models.ViewModel.Product
{
    public class ProductFindingViewModel
    {
        public List<ProductFinding> ProductFindings { get; set; }
     
    }

    public class ProductFinding
    {
        public string FindingName { get; set; }
        public int FindingID { get; set; }
    }




}
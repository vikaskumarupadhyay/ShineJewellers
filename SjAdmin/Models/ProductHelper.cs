using SjAdmin.Models.ViewModel.Product;
using SJModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SjAdmin.Models
{
    public class ProductHelper
    {
        #region finding helper
        public  ProductFindingViewModel ConvertFindingToViewModel(List<Finding> findings)
        {
            if (findings == null || findings.Count == 0)
                return null;

            ProductFindingViewModel productFindingViewModel = new ViewModel.Product.ProductFindingViewModel();

            productFindingViewModel.ProductFindings = new List<ProductFinding>();

            foreach (Finding finding in findings)
            {
                productFindingViewModel.ProductFindings.Add(GetViewModelProductFindingFromDbFinding(finding));
            }
            return productFindingViewModel;
        }

        public ProductFinding GetViewModelProductFindingFromDbFinding(Finding finding)
        {
            ProductFinding productFinding = new ProductFinding();
            productFinding.FindingID = finding.FindingId;
            productFinding.FindingName = finding.FindingName;
            return productFinding;
        }
        #endregion
    }
}
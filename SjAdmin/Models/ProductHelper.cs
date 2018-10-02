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


        #region Stone helper
        public List<StoneViewModel> GetViewModelFromDbStoneCollection(List<Stone> stoneCollection)
        {
            if (stoneCollection == null || stoneCollection.Count == 0)
            {
                return null;
            }
            List<StoneViewModel> stoneViewModelCollection = new List<ViewModel.Product.StoneViewModel>();

            foreach (Stone stone in stoneCollection)
            {
                StoneViewModel stoneViewModel = GetViewModelFromDbStone(stone);
                if(stoneViewModel!=null)
                stoneViewModelCollection.Add(stoneViewModel);
            }
            return stoneViewModelCollection;
        }

        public StoneViewModel GetViewModelFromDbStone(Stone stone)
        {
            StoneViewModel stoneViewModel = new StoneViewModel();
            stoneViewModel.StoneId = stone.StoneId;
            stoneViewModel.StoneName = stone.StoneName;
            stoneViewModel.IsActive = stone.IsActive;
            return stoneViewModel;
        }

        public Stone GetStoneObjectFromViewModelStone(StoneViewModel stoneViewModel)
        {
            Stone stone = new Stone();
            stone.StoneId = stoneViewModel.StoneId;
            stone.StoneName = stoneViewModel.StoneName;
            stone.IsActive = stoneViewModel.IsActive;
            return stone;
        }

        #endregion
    }
}
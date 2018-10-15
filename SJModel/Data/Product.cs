using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJModel.Data
{
    [Table("Product")]
    public partial class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string DesignNo { get; set; }
        public string DyeNo { get; set; }
        public string StyleNo { get; set; }

        public string ProductCode { get; set; }

        public int CategoryId { get; set; }

        public string SubCategoryId { get; set; }
        public decimal MasterWeight { get; set; }

        public decimal WaxWeight { get; set; }

        public bool? DisplayForB2B { get; set; }

        public bool? DisplayForB2C { get; set; }

        public bool? DisplayForB2BExclusive { get; set; }

        public decimal ExtimatedWeight_14KT { get; set; }
        public decimal ExtimatedWeight_18KT { get; set; }
        public decimal ExtimatedWeight_22KT { get; set; }



        public decimal GrossWeight_14KT { get; set; }
        public decimal GrossWeight_18KT { get; set; }
        public decimal GrossWeight_22KT { get; set; }



        public decimal NetWeight_14KT { get; set; }
        public decimal NetWeight_18KT { get; set; }
        public decimal NetWeight_22KT { get; set; }
        public bool? IsActive { get; set; }

        public string FindingIds { get; set; }
        public string FindingWeights { get; set; }

        public string StoneIds { get; set; }
        public string StoneWeights { get; set; }
        public string StoneDiscounts { get; set; }


        public bool ProductAvailableAs14Kt { get; set; }
        public bool ProductAvailableAs18Kt { get; set; }
        public bool ProductAvailableAs22Kt { get; set; }

        public DateTime? CreatedDate { get; set; }

        [NotMapped]
        public decimal Price { get; set; }


        [NotMapped]
        public decimal TotalFindingWeight
        {
            get
            {
                if (string.IsNullOrWhiteSpace(FindingWeights))
                    return 0.0M;

                decimal totalFindingWeight = CalculateTotal(FindingWeights);
                return totalFindingWeight;
            }

        }


        [NotMapped]
        public decimal TotalStoneWeight
        {
            get
            {
                if (string.IsNullOrWhiteSpace(StoneWeights))
                    return 0.0M;

                decimal totalFindingWeight = CalculateTotal(StoneWeights);
                return totalFindingWeight;
            }

        }


        [NotMapped]
        public decimal TotalStoneDiscount
        {
            get
            {
                if (string.IsNullOrWhiteSpace(StoneDiscounts))
                    return 0.0M;

                decimal totalFindingWeight = CalculateTotal(StoneDiscounts);
                return totalFindingWeight;
            }

        }

        private decimal CalculateTotal(string AmountisString)
        {
            decimal totalFindingWeight = 0.0M;
            if (AmountisString.Contains(","))
            {
                var splitedValue = AmountisString.Split(',');

                foreach (var value in splitedValue)
                {
                    decimal amount = 0.0M;

                    if (decimal.TryParse(value, out amount))
                    {
                        totalFindingWeight += amount;
                    }
                }
            }

            return totalFindingWeight;
        }
    }
}

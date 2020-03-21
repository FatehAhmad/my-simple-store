using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetProductsMVC.Models
{
    public class ProductPrice
    {
        public string CurrencyCode { get; set; }
        public decimal? SellPrice { get; set; }
        public decimal? RetailPrice { get; set; }
    }
}

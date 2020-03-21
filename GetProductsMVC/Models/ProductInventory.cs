using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetProductsMVC.Models
{
    public class ProductInventory
    {
        public string SKU { get; set; }
        public string AvailableQuantity { get; set; }
        public string MinActiveQuantity { get; set; }
        public decimal? GrossWeight { get; set; }
        public bool TrackInventory { get; set; }

    }
}




//"inventory": {
        //        "sku": "ITM0011",
        //        "availableQuantity": 110.0,
        //        "minActiveQuantity": 3.0,
        //        "grossWeight": null,
        //        "trackInventory": true
        //    },
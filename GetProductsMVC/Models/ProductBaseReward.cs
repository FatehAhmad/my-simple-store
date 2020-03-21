using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetProductsMVC.Models
{
    public class ProductBaseReward
    {
        public bool IsEnabled { get; set; }
        public int Points { get; set; }
        public decimal MinPayAmount { get; set; }
        public decimal minPointsAmount { get; set; }
    }
}








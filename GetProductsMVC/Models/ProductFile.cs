using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetProductsMVC.Models
{
    public class ProductFile
    {
        public int FieldId { get; set; }
        public string ContentType { get; set; }
        public string AccessPermission { get; set; }
        public string AccessUrl { get; set; }
        public string EdgeUrl { get; set; }
    }
}




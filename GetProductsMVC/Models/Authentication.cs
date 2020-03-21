using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetProductsMVC.Models
{
    public class Authentication
    {
        public string Access_Token { get; set; }
        public int Expires_In { get; set; }
        public string Token_Type { get; set; }
    }
}

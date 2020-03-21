using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetProductsMVC.Models
{
    public class ResponseObject<T>
    {
        public T Result { get; set; }
        public int PageSize { get; set; }
        public int pageIndex { get; set; }
        public int TotalRecordsFound { get; set; }
        public int ResultCount { get; set; }
        public int TotalPages { get; set; }
        public int QueryDurationMilliseconds { get; set; }
        public string StatusCode { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataForSeo.API.Requests
{
    public class DataRequestModel
    {
        public string Region { get; set; }
        public int LocationCode { get; set; }
        public string SearchEngine { get; set; }
        public List<string> KeyWords { get; set; }       
    }
}

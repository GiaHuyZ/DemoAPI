using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OAnQuanWebAPI.Common
{
    public class ApiResponse
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}

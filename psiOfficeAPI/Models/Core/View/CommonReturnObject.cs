using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace psiOfficeAPI.Models.Core.View
{
    public class CommonReturnObject
    {
        public Boolean success { get; set; }
        public string message { get; set; }
        public dynamic data { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace psiOfficeAPI.Models.Chart.View
{
    public class ChartVM
    {
        public string category { get; set; }
        public string series { get; set; }
        public decimal value { get; set; }
    }
}
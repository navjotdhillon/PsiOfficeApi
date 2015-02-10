using psiOfficeAPI.Models.Chart.View;
using psiOfficeAPI.Models.Core.View;
using psiOfficeAPI.Models.Report.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace psiOfficeAPI.Controllers
{
    public class ReportController : ApiController
    {
        [HttpGet]
        public CommonReturnObject ChartOneData()
        {
            List<ChartVM> dataVM = new ReportService().WorkloadPerWeek(0);

            return new CommonReturnObject() { success = true, message = "Chart One", data = dataVM };
        }

        [HttpGet]
        public CommonReturnObject ChartTwoData()
        {
            List<ChartVM> dataVM = new ReportService().WorkloadPerWeek(1);

            return new CommonReturnObject() { success = true, message = "Chart Two", data = dataVM };
        }

        [HttpGet]
        public CommonReturnObject ChartThreeData()
        {
            List<ChartVM> dataVM = new ReportService().WorkloadPerCustomer(1);

            return new CommonReturnObject() { success = true, message = "Chart Three", data = dataVM };
        }

        [HttpGet]
        public CommonReturnObject ChartFourData()
        {
            List<ChartVM> dataVM = new ReportService().WorkloadPerCustomerDollar(1);

            return new CommonReturnObject() { success = true, message = "Chart Four", data = dataVM };
        }

        [HttpGet]
        public CommonReturnObject SalesData()
        {
            List<ChartVM> dataVM = new ReportService().Sales();
            return new CommonReturnObject() { success = true, message = "Sales", data = dataVM };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using psiOfficeAPI.Models.Core.View;
using psiOfficeAPI.Models.Report.Service;

namespace psiOfficeAPI.Controllers
{
    public class ScheduleController : ApiController
    {
        [HttpGet]
        public CommonReturnObject OpRequest()
        {
            var dataVM = new ScheduleService().OpRequest();
            return new CommonReturnObject() { success = true, message = "Success", data = dataVM };
        }

        [HttpGet]
        public CommonReturnObject OpSchedule()
        {
            var dataVM = new ScheduleService().OpSchedule();
            return new CommonReturnObject() { success = true, message = "Success", data = dataVM };
        }

        [HttpGet]
        public CommonReturnObject OpProduction()
        {
            var dataVM = new ScheduleService().OpProduction();
            return new CommonReturnObject() { success = true, message = "Success", data = dataVM };
        }
    }
}

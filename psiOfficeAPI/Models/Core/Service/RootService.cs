using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace psiOfficeAPI.Models.Core.Service
{
    public class RootService
    {
        protected string ODBC
        {
            get { return "Dsn=psioffice;uid=psiapps;password=1SunWebData*2"; }
            //get { return "Dsn=psi_office_db;uid=psiapps;password=1SunWebData*2"; }
        }
    }
}
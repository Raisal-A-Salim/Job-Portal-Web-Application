using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobSiteApplication.Controllers
{
    public class CompHomeController : Controller
    {
        // GET: CompHome
        public ActionResult CompHome_PageLoad()
        {
            return View();
        }
    }
}
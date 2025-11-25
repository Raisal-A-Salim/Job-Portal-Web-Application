using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSiteApplication.Models;

namespace JobSiteApplication.Controllers
{
    public class JobInsertController : Controller
    {
        // GET: JobInsert
        JobSiteDBEntities dbobj = new JobSiteDBEntities();
        public ActionResult JobInsert_PageLoad()
        {
            return View();
        }
        public ActionResult JobInsert_ButtonClick(JobInsertCls clsobj)
        {
            if (!ModelState.IsValid)
            {
                return View("JobInsert_PageLoad", clsobj);
            }
            dbobj.sp_jobinsert(Convert.ToInt32(Session["Reg_ID"]), clsobj.Job_Title, clsobj.Job_Descr, clsobj.Location, clsobj.Salary, clsobj.Skills, clsobj.Experience, clsobj.LastDate, "Open");
            clsobj.msg = "Job created successfully";
            return View("JobInsert_PageLoad", clsobj);
        }
    }
}
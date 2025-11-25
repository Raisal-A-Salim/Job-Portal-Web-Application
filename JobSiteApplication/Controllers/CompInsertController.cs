using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSiteApplication.Models;

namespace JobSiteApplication.Controllers
{
    public class CompInsertController : Controller
    {
        // GET: CompInsert
        JobSiteDBEntities dbobj = new JobSiteDBEntities();
        public ActionResult CompInsert_PageLoad()
        {
            return View();
        }
        public ActionResult CompInsert_ButtonClick(CompInsertCls clsobj)
        {
            if (ModelState.IsValid)
            {
                int maxregid = Convert.ToInt32(dbobj.sp_loginidmax().FirstOrDefault());
                int regid = 0;
                if (maxregid == 0)
                    regid = 1;
                else
                    regid = maxregid + 1;
                dbobj.sp_companyinsert(regid, clsobj.Comp_Name, clsobj.Comp_Address, clsobj.Comp_Phone, clsobj.Comp_Description, clsobj.WebsiteAddress);
                dbobj.sp_loginsert(regid, clsobj.Username, clsobj.Password,"Company");
                clsobj.msg = "Successfully registered";
                return View("CompInsert_PageLoad", clsobj);
            }
            else
                return View("CompInsert_PageLoad", clsobj);
        }
    }
}
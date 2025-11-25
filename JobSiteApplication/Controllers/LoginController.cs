using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSiteApplication.Models;

namespace JobSiteApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        JobSiteDBEntities dbobj = new JobSiteDBEntities();
        public ActionResult Login_PageLoad()
        {
            return View();
        }
        public ActionResult Login_ButtonClick(LoginCls clsobj)
        {
            if (!ModelState.IsValid)
            {
                return View("Login_PageLoad", clsobj);
            }
            int cid = Convert.ToInt32(dbobj.sp_loginidcountget(clsobj.Username, clsobj.Password).FirstOrDefault());
            if (cid == 1)
            {
                Session["Reg_ID"] = dbobj.sp_selectlogid(clsobj.Username, clsobj.Password).FirstOrDefault();
                string Log_Type = dbobj.sp_selectusertype(clsobj.Username, clsobj.Password).FirstOrDefault();
                if (Log_Type == "User")
                {
                    return RedirectToAction("UserHome_PageLoad","UserHome");
                }
                else
                {
                    return RedirectToAction("CompHome_PageLoad", "CompHome");
                }
            }
            else
            {
                clsobj.msg = "Invalid username and password";
                return View("Login_PageLoad", clsobj);
            }
        }
    }
}
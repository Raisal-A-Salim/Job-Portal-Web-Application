using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSiteApplication.Models;

namespace JobSiteApplication.Controllers
{
    public class UserInsertController : Controller
    {
        // GET: UserInsert
        JobSiteDBEntities dbobj = new JobSiteDBEntities();
        public ActionResult UserInsert_PageLoad()
        {
            UserInsertCls user = new UserInsertCls();
            user.MyFavQuali = getQualiData();
            return View(user);
        }
        public List<CheckBoxListHelper> getQualiData()
        {
            List<CheckBoxListHelper> QualiList = new List<CheckBoxListHelper>()
            {
                new CheckBoxListHelper{Value="SSLC",Text="SSLC",IsChecked=true},
                new CheckBoxListHelper{Value="Plus Two",Text="Plus Two",IsChecked=false},
                new CheckBoxListHelper{Value="BCA",Text="BCA",IsChecked=false},
                new CheckBoxListHelper{Value="MCA",Text="MCA",IsChecked=false},
                new CheckBoxListHelper{Value="Diploma",Text="Diploma",IsChecked=false},
                new CheckBoxListHelper{Value="B.Tech",Text="B.Tech",IsChecked=false},
                new CheckBoxListHelper{Value="M.Tech",Text="M.Tech",IsChecked=false}
            };
            return QualiList;
        }
        public ActionResult UserInsert_ButtonClick(UserInsertCls clsobj, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                int maxregid = Convert.ToInt32(dbobj.sp_loginidmax().FirstOrDefault());
                int regid = 0;
                if (maxregid == 0)
                    regid = 1;
                else
                    regid = maxregid + 1;

                var total_quali = string.Join(", ", clsobj.SelectedQuali);
                clsobj.Qualification = total_quali; //set
                clsobj.MyFavQuali = getQualiData();//get

                dbobj.sp_userinsert(regid, clsobj.Name, clsobj.Age, clsobj.Address, clsobj.Email, clsobj.Phone, clsobj.Gender, clsobj.Qualification, clsobj.Skills, clsobj.Experience);
                dbobj.sp_loginsert(regid, clsobj.Username, clsobj.Password, "User");
                clsobj.msg = "Successfully registered";
                return View("UserInsert_PageLoad", clsobj);
            }
            else
            {
                clsobj.MyFavQuali = getQualiData();
                return View("UserInsert_PageLoad", clsobj);
            }
        }
    }
}
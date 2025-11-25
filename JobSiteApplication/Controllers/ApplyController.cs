using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using JobSiteApplication.Models;

namespace JobSiteApplication.Controllers
{
    public class ApplyController : Controller
    {
        // GET: Apply
        JobSiteDBEntities dbobj = new JobSiteDBEntities();
        public ActionResult Apply_PageLoad(int Job_ID)
        {
            var clsobj = GetJobDetails(Job_ID);

            string status = dbobj.sp_CheckAlreadyApplied(Job_ID, (int)Session["Reg_ID"]).FirstOrDefault();
            if (status == "Applied")
                ViewBag.Applied = true;
            else
                ViewBag.Applied = false;

            return View(clsobj);
        }
        public ApplyCls GetJobDetails(int Job_ID)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_JobSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", " AND Job_ID= " + Job_ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var clsobj = new ApplyCls();
                while (dr.Read())
                {
                    clsobj.job.Job_ID = (int)dr["Job_ID"];
                    clsobj.job.Comp_ID = (int)dr["Comp_ID"];
                    clsobj.job.Comp_Name = (string)dr["Comp_Name"];
                    clsobj.job.Job_Title = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(dr["Job_Title"].ToString().ToLower());
                    clsobj.job.Job_Descr = (string)dr["Job_Descr"];
                    clsobj.job.Location = (string)dr["Location"];
                    clsobj.job.Salary = (int)dr["Salary"];
                    clsobj.job.Skills = (string)dr["Skills"];
                    clsobj.job.Experience = (string)dr["Experience"];
                    clsobj.job.LastDate = (DateTime)dr["LastDate"];
                    clsobj.job.Job_Status = (string)dr["Job_Status"];
                }
                return clsobj;
            }
        }
        public ActionResult Apply_ButtonClick(ApplyCls clsobj, HttpPostedFileBase resume)
        {
            if (resume == null || resume.ContentLength == 0)
            {
                ModelState.AddModelError("CV", "Please upload your resume.");
            }

            int jobId = clsobj.job.Job_ID;

            var fullJobDetails = GetJobDetails(jobId);

            if (!ModelState.IsValid)
            {
                return View("Apply_PageLoad", fullJobDetails);
            }

            if (resume.ContentLength > 0 && resume != null)//control doesnt go into this if when fileupload wasnt proper
            {
                string filename = Path.GetFileName(resume.FileName);
                var s = Server.MapPath("~/Resumes");
                string pa = Path.Combine(s, filename);
                resume.SaveAs(pa);
                var fullpath = Path.Combine("~\\Resumes", filename);
                clsobj.CV = fullpath;//set
            }

            clsobj.Appl_Date = DateTime.Now;

            int i = dbobj.sp_InsertApplication(jobId, (int)Session["Reg_ID"], clsobj.CV, clsobj.Appl_Date, "Applied");
            if (i == 1)
            {
                ViewBag.Applied = true;
                ViewBag.Message = "Applied Successfully";
            }
            return View("Apply_PageLoad", fullJobDetails);
        }
    }
}
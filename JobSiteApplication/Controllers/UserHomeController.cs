using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSiteApplication.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace JobSiteApplication.Controllers
{
    public class UserHomeController : Controller
    {
        // GET: UserHome
        public ActionResult UserHome_PageLoad()
        {
            UserHomeCls clsobj = new UserHomeCls();
            return View(GetJobs(clsobj));
        }
        public string GetQuery(UserHomeCls clsobj)
        {
            string query = "";
            if (!string.IsNullOrWhiteSpace(clsobj.Input_Experience))
                query += " AND Experience LIKE '%" + clsobj.Input_Experience + "%'";
            if (!string.IsNullOrWhiteSpace(clsobj.Input_Location))
                query += " AND Location LIKE '%" + clsobj.Input_Location + "%'";
            if (!string.IsNullOrWhiteSpace(clsobj.Input_Skills))
                query += " AND Skills LIKE '%" + clsobj.Input_Skills + "%'";
            return query;
        }
        public UserHomeCls GetJobs(UserHomeCls clsobj)
        {
            using(var con=new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_JobSearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry",GetQuery(clsobj));
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var OneJob = new JobDetailCls();
                    OneJob.Job_ID = (int)dr["Job_ID"];
                    OneJob.Comp_ID = (int)dr["Comp_ID"];
                    OneJob.Comp_Name = (string)dr["Comp_Name"];
                    OneJob.Job_Title = (string)dr["Job_Title"];
                    OneJob.Job_Descr = (string)dr["Job_Descr"];
                    OneJob.Location = (string)dr["Location"];
                    OneJob.Salary = (int)dr["Salary"];
                    OneJob.Skills = (string)dr["Skills"];
                    OneJob.Experience = (string)dr["Experience"];
                    OneJob.LastDate = (DateTime)dr["LastDate"];
                    OneJob.Job_Status = (string)dr["Job_Status"];

                    clsobj.JobList.Add(OneJob);
                }
                return clsobj;
            }
        }
        public ActionResult SearchButtonClick(UserHomeCls clsobj)
        {
            var filtered = GetJobs(clsobj);
            return View("UserHome_PageLoad", filtered);
        }
    }
}
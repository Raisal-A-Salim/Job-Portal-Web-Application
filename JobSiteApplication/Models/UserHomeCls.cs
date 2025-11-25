using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSiteApplication.Models
{
    public class UserHomeCls
    {
        public string Input_Location { get; set; }
        public string Input_Skills { get; set; }
        public string Input_Experience { get; set; }
        public List<JobDetailCls> JobList { get; set; } = new List<JobDetailCls>();
    }
    public class JobDetailCls
    {
        public int Job_ID { get; set; }
        public int Comp_ID { get; set; }
        public string Comp_Name { get; set; }
        public string Job_Title { get; set; }
        public string Job_Descr { get; set; }
        public string Location { get; set; }
        public int Salary { get; set; }
        public string Skills { get; set; }
        public string Experience { get; set; }
        public System.DateTime LastDate { get; set; }
        public string Job_Status { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSiteApplication.Models
{
    public class ApplyCls
    {
        public string CV { get; set; }
        public DateTime Appl_Date { get; set; }
        public JobDetailCls job { get; set; } = new JobDetailCls();
    }
}
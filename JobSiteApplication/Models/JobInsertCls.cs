using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSiteApplication.Models
{
    public class JobInsertCls
    {
        [Required(ErrorMessage = "Enter a title")]
        public string Job_Title { get; set; }

        [Required(ErrorMessage = "Enter a description")]
        public string Job_Descr { get; set; }

        [Required(ErrorMessage = "Enter a location")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Enter a salary")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Enter skills required")]
        public string Skills { get; set; }

        [Required(ErrorMessage = "Enter experience required")]
        public string Experience { get; set; }
        public System.DateTime LastDate { get; set; }
        public string msg { get; set; }
    }
}
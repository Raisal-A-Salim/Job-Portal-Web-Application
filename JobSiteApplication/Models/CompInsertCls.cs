using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSiteApplication.Models
{
    public class CompInsertCls
    {
        [Required(ErrorMessage = "Enter a name")]
        public string Comp_Name { get; set; }

        [Required(ErrorMessage = "Enter an address")]
        public string Comp_Address { get; set; }

        [Required(ErrorMessage = "Enter a phone")]
        public long Comp_Phone { get; set; }

        [Required(ErrorMessage = "Enter a description")]
        public string Comp_Description { get; set; }

        [Required(ErrorMessage = "Enter a website address")]
        public string WebsiteAddress { get; set; }

        [Required(ErrorMessage = "Enter a username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter a password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required")]
        [Compare("Password",ErrorMessage = "Passwords donot match")]
        public string ConfirmPassword { get; set; }

        public string msg { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSiteApplication.Models
{
    public class LoginCls
    {
        [Required(ErrorMessage = "Enter a username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter a password")]
        public string Password { get; set; }
        public string msg { get; set; }
    }
}
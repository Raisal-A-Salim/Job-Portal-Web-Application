using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSiteApplication.Models
{
    public class CheckBoxListHelper
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool IsChecked { get; set; }
    }
    public class UserInsertCls
    {
        public List<CheckBoxListHelper> MyFavQuali { get; set; }
        public string[] SelectedQuali { get; set; }

        [Required(ErrorMessage = "Enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter an age")]
        [Range(18, 60, ErrorMessage = "Age must be between 18 and 60")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Enter a address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter an email address")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter a phone number")]
        [RegularExpression(@"^(\+91[-\s]?)?[6-9]\d{9}$", ErrorMessage = "Enter a valid phone number")]
        public long Phone { get; set; }

        [Required(ErrorMessage = "Provide a gender")]
        public string Gender { get; set; }
        public string Qualification { get; set; }
        public string Skills { get; set; }
        public string Experience { get; set; }

        [Required(ErrorMessage = "Enter a username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter a password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required")]
        [Compare("Password", ErrorMessage = "Passwords donot match")]
        public string ConfirmPassword { get; set; }

        public string msg { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZookeeperApp.Models
{
    //This classes are responsible for login and registration
    public class LoginViewModel
    {
        [EmailAddress]
        [Required]
        [Display(Name ="Email address")]
        public string Email { get; set; }
        
        [Required]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class RegisterViewModel
    {
        [EmailAddress]
        [Required]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password is not matching")]
        public string ConfirmPassword { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinical_Automation_System.ViewModel
{
    public class ForgotPS
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
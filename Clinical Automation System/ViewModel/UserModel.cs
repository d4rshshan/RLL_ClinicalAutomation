using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clinical_Automation_System.ViewModel
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime DOB { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
    }
}
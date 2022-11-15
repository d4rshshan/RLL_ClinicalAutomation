using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CAS_BAL;

namespace Clinical_Automation_System.ViewModel
{
    public class AppointmentModel
    {
        public int AppointmentId { get; set; }
        public System.DateTime StartDateTime { get; set; }
        public string Status { get; set; }
        public string Details { get; set; }
        public bool IsApprove { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        //public virtual User User { get; set; }
        //public virtual User User1 { get; set; }
    }
}
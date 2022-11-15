using CAS_BAL;
using Clinical_Automation_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Clinical_Automation_System.Controllers
{
    public class AppointmentAPIController : ApiController
    {
        AppointmentsDAL ms = null;
        public AppointmentAPIController()
        {
            ms = new AppointmentsDAL();
        }
        List<AppointmentModel> s = new List<AppointmentModel>();
        // GET api/<controller>
        [Route("GetAllAppointmentsDetails")]
        public IEnumerable<AppointmentModel> Get()
        {
            List<Appointment> c = ms.GetAllAppointments();
            foreach (var item in c)
            {
                AppointmentModel v = new AppointmentModel();
                v.AppointmentId = item.AppointmentId;
                v.StartDateTime = item.StartDateTime;
                v.PatientId = item.PatientId;
                v.Status = item.Status;
                v.Details = item.Details;
                v.IsApprove = item.IsApprove;
                v.DoctorId= item.DoctorId;

                s.Add(v);
            }
            return s;
        }

        // GET api/<controller>/5
        [Route("GetAppointmentByID/{id}")]
        public AppointmentModel Get(int id)
        {
            AppointmentModel r = new AppointmentModel();
            Appointment p = new Appointment();
            p = ms.GetAppointmentByID(id);

            r.AppointmentId = Convert.ToInt32(p.AppointmentId);
            r.DoctorId = Convert.ToInt32(p.DoctorId);
            r.PatientId = Convert.ToInt32(p.PatientId);
            r.Status = p.Status.ToString();
            r.StartDateTime = Convert.ToDateTime(p.StartDateTime);
            r.Details = p.Details.ToString();
            r.IsApprove = Convert.ToBoolean(p.IsApprove);

            return r;
        }

        // POST api/<controller>
        [Route("SavingAppointment")]
        public HttpResponseMessage Post([FromBody] AppointmentModel value)
        {
            Appointment r = new Appointment();
            r.AppointmentId = value.AppointmentId;
            r.PatientId = value.PatientId;
            r.DoctorId = value.DoctorId;
            r.Status = value.Status;
            r.Details = value.Details;
            r.StartDateTime = value.StartDateTime;
            r.IsApprove = value.IsApprove;


            bool k = ms.AddAppointment(r);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }

        // PUT api/<controller>/5
        [Route("UpdateAppointment/{id}")]
        public HttpResponseMessage Put(int id, [FromBody] AppointmentModel value)
        {
            Appointment r = new Appointment();
            r.AppointmentId = value.AppointmentId;
            r.PatientId = value.PatientId;
            r.DoctorId = value.DoctorId;
            r.Status = value.Status;
            r.Details = value.Details;
            r.StartDateTime = value.StartDateTime;
            r.IsApprove = value.IsApprove;

            bool k = ms.UpdateAppointment(id, r);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }

        // DELETE api/<controller>/5
        [Route("DeleteAppointment/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            bool k = ms.DeleteAppointment(id);
            if (k)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }
    }
}
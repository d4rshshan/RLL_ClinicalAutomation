﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS_DAL.Repositories
{
   public class AppointmentRepository : BaseRepository, IRepository<Appointment>
    {
        public int Add(Appointment item)
        {
            myContext.Appointments.Add(item);
            int result = myContext.SaveChanges();
            if (result > 0)
                return 1;
            else
                return 0;
        }
        public bool Update(Appointment item)
        {
            Appointment appointment = myContext.Appointments.Where(a => a.AppointmentId == item.AppointmentId).SingleOrDefault();
            appointment = item;
            int result = myContext.SaveChanges();
            if (result > 0)
                return true;
            else
                return false;
        }

        public IEnumerable<Appointment> GetAll()
        {
            IEnumerable<Appointment> appointments = myContext.Appointments.Include("User").
                OrderBy(app => app.AppointmentId);
            return appointments;
        }

        public Appointment GetById(int id)
        {
           Appointment appointment = myContext.Appointments.Include("User").Where(app=>app.AppointmentId==id).
               OrderBy(app => app.AppointmentId).SingleOrDefault();
            return appointment;
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> Search(string name)
        {
            IEnumerable <Appointment> appointments = myContext.Appointments.Include("User").Where(app => app.User.Name.ToLower().Contains(name.ToLower())).
               OrderBy(app => app.AppointmentId);
            return appointments;
        }


        public IEnumerable<Appointment> SearchbyAppDate(DateTime date)
        {
            IEnumerable<Appointment> appointments = myContext.Appointments.Include("User").
                OrderBy(a => a.AppointmentId).Where(a => System.Data.Entity.DbFunctions.TruncateTime(a.StartDateTime) == date.Date);
            return appointments;
        }

        public IEnumerable<Appointment> SearchbyPateintAppDate(DateTime date,int id)
        {
            IEnumerable<Appointment> appointments = myContext.Appointments.Include("User").
                OrderBy(a => a.AppointmentId).Where(a => System.Data.Entity.DbFunctions.TruncateTime(a.StartDateTime) == date.Date && a.PatientId == id);
            return appointments; 
        }


        public IEnumerable<Appointment> SearchbyPateintId(int id)
        {
            IEnumerable<Appointment> appointments = myContext.Appointments.Include("User").
                OrderBy(a => a.AppointmentId).Where(a => a.PatientId == id);
            return appointments;
        }

        public IEnumerable<Appointment> SearchbyPateintIdApproved(int id)
        {
            IEnumerable<Appointment> appointments = myContext.Appointments.Include("User").
                OrderBy(a => a.AppointmentId).Where(a => a.PatientId == id && a.IsApprove==true);
            return appointments;
        }

        public IEnumerable<Appointment> SearchbyDoctorAppDate(DateTime date, int id)
        {
            IEnumerable<Appointment> appointments = myContext.Appointments.Include("User").
                OrderBy(a => a.AppointmentId).Where(a => a.DoctorId == id && System.Data.Entity.DbFunctions.TruncateTime(a.StartDateTime) == date.Date && a.IsApprove==true);
            return appointments;
        }


        public IEnumerable<Appointment> SearchbyDoctorId(int id)
        {
            IEnumerable<Appointment> appointments = myContext.Appointments.Include("User").
                OrderBy(a => a.AppointmentId).Where(a => a.DoctorId == id && a.IsApprove == true);
            return appointments;
        }
    }
}

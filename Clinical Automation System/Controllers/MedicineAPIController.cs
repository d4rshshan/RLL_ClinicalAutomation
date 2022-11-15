using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CAS_BAL;
using Clinical_Automation_System.ViewModel;

namespace Clinical_Automation_System.Controllers
{
    public class MedicineAPIController : ApiController
    {
        MedicineDAL ms = null;
        public MedicineAPIController()
        {
            ms = new MedicineDAL();
        }
        List<MedicineViewModel> s = new List<MedicineViewModel>();
        // GET api/<controller>
        [Route("GetAllMedsDetails")]
        public IEnumerable<MedicineViewModel> Get()
        {
            List<Medicine> c = ms.GetAllMeds();
            foreach (var item in c)
            {
                MedicineViewModel v = new MedicineViewModel();
                v.MedicineId= item.MedicineId;
                v.Name = item.Name;
                v.Price= (float)item.Price;
                v.Stock = item.Stock;
                v.Tax = (float)item.Tax;
                v.IsAvailable = item.IsAvailable;
                v.IsActive = item.IsActive;
                s.Add(v);
            }
            return s;
        }

        // GET api/<controller>/5
        [Route("GetMedsByID/{id}")]
        public MedicineViewModel Get(int id)
        {
            MedicineViewModel r = new MedicineViewModel();
            Medicine p = new Medicine();
            p = ms.GetMedsByid(id);

            r.MedicineId = Convert.ToInt32(p.MedicineId);
            r.Name = p.Name.ToString();
            r.Price = Convert.ToInt32(p.Price);
            r.Stock = Convert.ToInt32(p.Stock);
            r.Tax = Convert.ToInt32(p.Tax);
            return r;
        }

        // POST api/<controller>
        [Route("SavingMeds")]
        public HttpResponseMessage Post([FromBody] MedicineViewModel value)
        {
            Medicine r = new Medicine();
            r.MedicineId = value.MedicineId;
            r.Name = value.Name;
            r.Price = value.Price;
            r.Stock = value.Stock;
            r.Tax = value.Tax;
            r.IsAvailable = value.IsAvailable;
            r.IsActive = value.IsActive;

            bool k = ms.AddMeds(r);
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
        [Route("UpdateMeds/{id}")]
        public HttpResponseMessage Put(int id, [FromBody] MedicineViewModel value)
        {
            Medicine r = new Medicine();
            r.MedicineId = value.MedicineId;
            r.Name = value.Name;
            r.Price = value.Price;
            r.Stock = value.Stock;
            r.Tax = value.Tax;
            r.IsAvailable = value.IsAvailable;
            r.IsActive = value.IsActive;

            bool k = ms.UpdateMeds(id, r);
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
        [Route("DeleteMeds/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            bool k = ms.DeleteMeds(id);
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
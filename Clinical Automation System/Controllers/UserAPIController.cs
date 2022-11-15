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
    public class UserAPIController : ApiController
    {
        UsersDAL ms = null;
        public UserAPIController()
        {
            ms = new UsersDAL();
        }
        List<UserModel> s = new List<UserModel>();
        // GET api/<controller>
        [Route("GetAllUserDetails")]
        public IEnumerable<UserModel> Get()
        {
            List<User> c = ms.GetAllUsers();
            foreach (var item in c)
            {
                UserModel v = new UserModel();
                v.UserId = item.UserId;
                v.Name = item.Name;
                v.Phone = item.Phone;
                v.Address = item.Address;
                v.DOB = item.DOB;
                v.Gender = item.Gender;
                v.Email = item.Email;
                v.IsActive = item.IsActive;
                v.RoleId = item.RoleId;
                s.Add(v);
            }
            return s;
        }

        // GET api/<controller>/5
        [Route("GetUserByID/{id}")]
        public UserModel Get(int id)
        {
            UserModel r = new UserModel();
            User p = new User();
            p = ms.GetUserByid(id);

            r.UserId = Convert.ToInt32(p.UserId);
            r.Name = p.Name.ToString();
            r.Phone = p.Phone.ToString();
            r.Address = p.Address.ToString();
            r.DOB = Convert.ToDateTime(p.DOB);
            r.Gender = p.Gender.ToString();
            r.Email = p.Email.ToString();
            r.IsActive = Convert.ToBoolean(p.IsActive);
            r.RoleId = Convert.ToInt32(p.RoleId);
            return r;
        }

        // POST api/<controller>
        [Route("SavingUser")]
        public HttpResponseMessage Post([FromBody] UserModel value)
        {
            User r = new User();
            r.UserId = value.UserId;
            r.Name = value.Name;
            r.Phone = value.Phone;
            r.Address = value.Address;
            r.DOB = value.DOB;
            r.Gender = value.Gender;
            r.Email= value.Email;
            r.Password = value.Password;
            r.IsActive = value.IsActive;
            r.RoleId = value.RoleId;

            bool k = ms.AddUser(r);
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
        [Route("UpdateUser/{id}")]
        public HttpResponseMessage Put(int id, [FromBody] UserModel value)
        {
            User r = new User();
            r.UserId = value.UserId;
            r.Name = value.Name;
            r.Phone = value.Phone;
            r.Address = value.Address;
            r.DOB = value.DOB;
            r.Gender = value.Gender;
            r.Email = value.Email;
            r.Password = value.Password;
            r.IsActive = value.IsActive;
            r.RoleId = value.RoleId;

            bool k = ms.UpdateUser(id, r);
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
        [Route("DeleteUser/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            bool k = ms.DeleteUser(id);
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
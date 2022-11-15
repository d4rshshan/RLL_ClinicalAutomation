using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAS_BAL;
namespace CAS_Test
{
    public class validate
    {
        CASEntities db = new CASEntities();
        public bool Admin_Check()
        {
            bool ans = false;
            var found = db.Users.ToList();
            if (found[0].Email == "kannan@gmail.com" && found[0].Password == "123")
            {
                ans = true;
            }
            return ans;
        }
        public bool Doctor_Check()
        {
            bool ans = false;
            var found = db.Users.ToList();
            if (found[0].Email == "ram@gmail.com" && found[0].Password == "123")
            {
                ans = true;
            }
            return ans;
        }
        public bool Frontofficer_check()
        {
            bool ans = false;
            var found = db.Users.ToList();
            if (found[0].Email == "deepak@gmail.com" && found[0].Password == "123")
            {
                ans = true;
            }
            return ans;
        }
        public bool Pharmacist_check()
        {
            bool ans = false;
            var found = db.Users.ToList();
            if (found[0].Email == "gurus@gmail.com" && found[0].Password == "123")
            {
                ans = true;
            }
            return ans;
        }
        public bool Patient_check()
        {
            bool ans = false;
            var found = db.Users.ToList();
            if (found[0].Email == "naren@gmail.com" && found[0].Password == "123")
            {
                ans = true;
            }
            return ans;
        }
    }
}

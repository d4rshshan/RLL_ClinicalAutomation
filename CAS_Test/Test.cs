using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAS_BAL;
using NUnit.Framework;

namespace CAS_Test
{
    public class Test
    {
       
        validate v = new validate();
        [TestCase]
        public void Admin_Test()
        {

            v.Admin_Check();
        }
        [TestCase]
        public void Doctor_Test()
        {

            v.Doctor_Check();
        }
        [TestCase]
        public void Frontofficer_Test()
        {

            v.Frontofficer_check();
        }
        [TestCase]
        public void Pharmacist_Test()
        {

            v.Pharmacist_check();
        }
        [TestCase]
        public void Patient_Test()
        {

            v.Patient_check();
        }
    }
}

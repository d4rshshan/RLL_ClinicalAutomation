using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAS_DAL.Repositories;
using CAS_DAL;
using Clinical_Automation_System.ViewModel;
using System.Threading.Tasks;

namespace Clinical_Automation_System.Controllers
{
    public class AccountController : Controller
    {
        UserRepository userRepository;

        public AccountController()
        {
            userRepository = new UserRepository();
        }
        public ActionResult WelcomePage()
        {
            return View();
        }

        // GET: /Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string inputEmail, string inputPassword)
        {
            User user = userRepository.LoginUsingEmailAndPassword(inputEmail, inputPassword);
            if (user == null)
            {
                Session["Invalid"] = true;
                return View();
            }
            else
            {
                Session["UserId"] = user.UserId;
                Session["Name"] = user.Name;
                Session["RoleId"] = user.RoleId;
                //'Administrator'
                if (user.RoleId == 1)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Admin",
                        action = "index",
                    });
                }
                //'Doctor'
                else if (user.RoleId == 2)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Doctor",
                        action = "Index",
                    });
                }
                //'Patient'
                else if (user.RoleId == 3)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Patient",
                        action = "Index",
                    });
                }

                //'Fontoffice'
                else if (user.RoleId == 4)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Fontoffice",
                        action = "Index",
                    });
                }

                //'Pharmacy'
                else if (user.RoleId == 5)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Pharmacy",
                        action = "Index",
                    });

                }
                else
                {
                    return View();
                }


            }

        }

        [HttpPost]
        public ActionResult Logout()
        {
            if ((int)Session["userid"] == 0 && ((int)Session["RoleId"] != 1))
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "WelcomePage",
                });
            }
            Session["UserId"] = 0;
            Session["Name"] = "";
            Session["RoleId"] = 0;
            Session["Invalid"] = false;
            return RedirectToRoute(new
            {
                controller = "account",
                action = "WelcomePage",
            });
        }

        [HttpGet]
        public ActionResult EditUser()
        {
           
            User u = userRepository.GetById((int)Session["UserId"]);
            RedirectToAction("Index");
            ViewBag.Edit = false;
            return View(u);
        }
        [HttpPost]
        public ActionResult EditUser(User usr)
        {
            if ((int)Session["userid"] == 0)
            {
                return RedirectToRoute(new
                {
                    controller = "account",
                    action = "login",
                });
            }
            bool res = userRepository.Update(usr);
            ViewBag.Edit = true;
            User u = userRepository.GetById(usr.UserId);
            return View(u);
        }

        [HttpGet]
        public ActionResult AddPatient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPatient(User user)
        {
            int res = userRepository.Add(user);
            return RedirectToAction("PatientLogin");
        }

        [HttpGet]
        public ActionResult PatientLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PatientLogin(string inputEmail, string inputPassword)
        {
            User user = userRepository.LoginUsingEmailAndPassword(inputEmail, inputPassword);
            if (user == null)
            {
                Session["Invalid"] = true;
                return View();
            }
            else
            {
                Session["UserId"] = user.UserId;
                Session["Name"] = user.Name;
                Session["RoleId"] = user.RoleId;
                //'Patient'
                if (user.RoleId == 3)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Patient",
                        action = "index",
                    });
                }
                else
                {
                    return View();
                }
            }
        }
        [HttpGet]
        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(string inputEmail, string inputphone)
        {
            User user = userRepository.LoginUsingEmailAndPhone(inputEmail, inputphone);
            if (user == null)
            {
                Session["Invalid"] = true;
                return View();
            }
            else
            {
                Session["UserId"] = user.UserId;
                Session["Name"] = user.Name;
                Session["RoleId"] = user.RoleId;
                //'Administrator'
                if (user.RoleId == 1)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Account",
                        action = "EditUser",
                    });
                }
                //'Doctor'
                else if (user.RoleId == 2)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Account",
                        action = "EditUser",
                    });
                }
                //'Patient'
                else if (user.RoleId == 3)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Account",
                        action = "EditUser",
                    });
                }

                //'Fontoffice'
                else if (user.RoleId == 4)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Account",
                        action = "EditUser",
                    });
                }

                //'Pharmacy'
                else if (user.RoleId == 5)
                {
                    return RedirectToRoute(new
                    {
                        controller = "Account",
                        action = "EditUser",
                    });

                }
                else
                {
                    return View();
                }
            }
        }

    }
}

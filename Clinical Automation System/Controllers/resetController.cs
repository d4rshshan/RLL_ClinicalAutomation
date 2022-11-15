using CAS_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAS_DAL;
namespace Clinical_Automation_System.Controllers
{
    public class resetController : Controller
    {
        UserRepository userRepository;

        public resetController()
        {
            userRepository = new UserRepository();
        }
        // GET: reset
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
                        action = "Edit",
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
        ///////
        ///
        [HttpGet]
        public ActionResult Edit()
        {

            User u = userRepository.GetById((int)Session["UserId"]);
            RedirectToAction("Index");
            ViewBag.Edit = false;
            return View(u);
        }
        [HttpPost]
        public ActionResult Edit(User usr)
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


    }
}
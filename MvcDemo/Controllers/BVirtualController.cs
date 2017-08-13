using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class BVirtualController : Controller
    {
        //
        // GET: /BVirtual/

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string userName = form["txtUserName"];
            string password = form["txtPassword"];
            string loginType = form["ddlLoginType"];

            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(loginType))
            {
                var obj = MvcDemo.Models.UserLogin.Login(userName, password, loginType == "P");
                if (null == obj)
                {
                    ViewBag.Error = "Login Error.";
                }
                else
                {
                    if (obj.IsProctor)
                    {
                        return Proctor(obj);
                    }
                    else
                    {
                        return Student(obj);
                    }
                }
            }
            else
            {
                ViewBag.Error = "User name and login type is required.";
            }
            return View();
        }

        public ActionResult Proctor(MvcDemo.Models.UserInfo user)
        {
            return View("Proctor", user);
        }
        public ActionResult Student(MvcDemo.Models.UserInfo user)
        {
            return View("Student", user);
        }

    }

}

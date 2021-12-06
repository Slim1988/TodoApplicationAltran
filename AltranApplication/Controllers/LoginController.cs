using AltranApplication.Models;
using AltranApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AltranApplication.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserServices _services = new UserServices();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(User user)
        {
            var currentUser = _services.CheckUser(user);

            if (currentUser == null)
            {
                ViewBag.Message = "Wrong Username or password";
                return View("Index", user);
            }

            else
            {
                Session["UserId"] = currentUser.UserId;
                Session["UserName"] = currentUser.UserName;
                return RedirectToAction("Index", "ToDo");

            }

        }

    }
}
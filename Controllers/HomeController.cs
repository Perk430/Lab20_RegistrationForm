using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab20_RegistrationForm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Register()
        {

            ViewBag.Message = "Please fill the form to register!";
            
            return View();
        }

        public ActionResult AddUser(string FirstName)
        {
            //code to add user
            string fName = FirstName;
            ViewBag.FirstName = fName;

            return View();
        }
    }
}
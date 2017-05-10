using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lab20_RegistrationForm.Models;

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

        public ActionResult AddUser(UserInfo NewUser)
        {
            //validation!!!!

            //to add the data from the model to the database
            
            //pass the NewUser model to the AddUser view
            return View(NewUser); 
        }
    }
}
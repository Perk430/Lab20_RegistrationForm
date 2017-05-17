using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using Lab20_RegistrationForm.Models;

namespace Lab20_RegistrationForm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CoffeeShopDBEntities DB = new CoffeeShopDBEntities();
            List<Item> ItemInfo = DB.Items.ToList();
            ViewBag.ItemInfo = ItemInfo;
            return View();
        }

        public ActionResult Admin()
        {
            CoffeeShopDBEntities DB = new CoffeeShopDBEntities();
            List<Item> ItemName = DB.Items.ToList();
            ViewBag.ItemInfo = ItemName;
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

        public ActionResult ListAllItems()
        {
            CoffeeShopDBEntities DB = new CoffeeShopDBEntities();
            // select * from items
            List<Item> ItemList = DB.Items.ToList();

            ViewBag.ItemList = ItemList;

            return View();
        }

        public ActionResult DeleteItem(string ItemName)
        {
            CoffeeShopDBEntities DB = new CoffeeShopDBEntities();

            Item ToDelete = DB.Items.Find(ItemName);

            DB.Items.Remove(ToDelete);

            DB.SaveChanges();

            return RedirectToAction("Admin","Home");
        }

        public ActionResult AddItem()
        {
            return View();
        }

        public ActionResult SaveNewItem(Item NewItem)
        {
            //The following code is validation for saving the new items to the database.
            CoffeeShopDBEntities DB = new CoffeeShopDBEntities();

            DB.Items.Add(NewItem);

            DB.SaveChanges();

            return RedirectToAction("ListAllItems");
        }

        public ActionResult SaveUpdates(Item ToBeUpdated)
        {
            CoffeeShopDBEntities DB = new CoffeeShopDBEntities();
            //find the original customer record
            Item ToFind = DB.Items.Find(ToBeUpdated.ItemName);

            ToFind.Description = ToBeUpdated.Description;

            ToFind.Quantity = ToBeUpdated.Quantity;

            ToFind.ItemPrice = ToBeUpdated.ItemPrice;

            DB.SaveChanges();

            return RedirectToAction("ListAllItems");
        }
    }
}
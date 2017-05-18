using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using Lab20_RegistrationForm.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Lab20_RegistrationForm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CoffeeShopDBEntities DB = new CoffeeShopDBEntities();
            List<Item> ItemInfo = DB.Items.ToList();
            ViewBag.ItemInfo = ItemInfo;
            ViewBag.RandomQuote = GetRandomQuote();
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

            return RedirectToAction("Index");
        }

        public ActionResult SaveUpdates(Item ToBeUpdated)
        {
            CoffeeShopDBEntities DB = new CoffeeShopDBEntities();
            //find the original customer record
            Item ToFind = DB.Items.Find(ToBeUpdated.ItemName);

            ToFind.ItemName = ToBeUpdated.ItemName;

            ToFind.Description = ToBeUpdated.Description;

            ToFind.Quantity = ToBeUpdated.Quantity;

            ToFind.ItemPrice = ToBeUpdated.ItemPrice;

            DB.SaveChanges();

            return RedirectToAction("ListAllItems");
        }

        public string GetRandomQuote()
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://andruxnet-random-famous-quotes.p.mashape.com/");

            //request.UserAgent = @"User-Agent: Mozilla/5.0(Windows NT 10.0; WOW64)AppleWebKit/537.36(KHTML, like Gecko) Chrome/53.0.2785.116 Safari/537.36";


            //add a key to your API call
            request.Headers.Add("X-Mashape-Key", "lfnQbQxPMimshpxyU980WGjDgykep1VmM3PjsnKpJVgNJyPhZh");//Key given by website
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "application/json";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string data = rd.ReadToEnd(); //raw format

            JObject RandomQuote = JObject.Parse(data);

            //ViewBag.Message = WeatherData["productionCenter"];
            //ViewBag.Message = WeatherData["location"]["timezone"];

            return RandomQuote["quote"].ToString();
        }
    }
}
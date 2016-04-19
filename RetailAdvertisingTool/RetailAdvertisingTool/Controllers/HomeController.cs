using RetailAdvertisingTool.Models;
using Salesforce.Force;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetailAdvertisingTool.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                if (Session["AccessToken"].ToString() != null)
                {
                    ViewBag.button = "Connected";
                }
            }catch(Exception e)
            {
                ViewBag.button = "Connect to Salesforce";
            }

            return View();
        }

        public ActionResult About()
        {
            try
            {
                var accessToken = Session["AccessToken"].ToString();
                var apiVersion = Session["ApiVersion"].ToString();
                var internalURI = Session["InstanceUrl"].ToString();


                //var client = new ForceClient(apiVersion,internalURI, accessToken);
                var client = new ForceClient(internalURI, accessToken, apiVersion);

                List<Buyer> model = client.QueryAsync<Buyer>("SELECT Id, Name, Buying_Office__c FROM Buyer__c").Result.Records;
                ViewBag.Message = "Your application description page.";

                return View(model);
            }
            catch(Exception e)
            {
                return RedirectToAction("Index", "InventoryManager");
            }
       
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "How can we help you?";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(string message)
        {
            
            ViewBag.Message = "Thanks! We got your message!";

            return View(); 
        }
    }
}
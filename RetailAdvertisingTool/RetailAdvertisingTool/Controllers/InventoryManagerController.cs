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
    public class InventoryManagerController : Controller
    {
        // GET: InventoryManager
        public ActionResult Index()
        {
            return View();
        }

        // GET: InventoryManager/Details/5
        public ActionResult Details(String name)
        {
            
            var accessToken = Session["AccessToken"].ToString();
            var apiVersion = Session["ApiVersion"].ToString();
            var internalURI = Session["InstanceUrl"].ToString();


            //var client = new ForceClient(apiVersion,internalURI, accessToken);
            var client = new ForceClient(internalURI, accessToken, apiVersion);

            InventoryManager model = client.QueryAsync<InventoryManager>("SELECT Id, Name, CostPrice__c, OwnedPrice__c, RetailCost__c, CurrentInventory__c, InventoryOnOrder__c, SampleInHouse__c, ProductPicture__c FROM Inventory__c WHERE Name="+"'"+name+"'").Result.Records.SingleOrDefault();

            return View(model);
           
        }



        public ActionResult ListInventory()
        {
            try
            {
                var accessToken = Session["AccessToken"].ToString();
                var apiVersion = Session["ApiVersion"].ToString();
                var internalURI = Session["InstanceUrl"].ToString();


                //var client = new ForceClient(apiVersion,internalURI, accessToken);
                var client = new ForceClient(internalURI, accessToken, apiVersion);

                List<InventoryManager> model = client.QueryAsync<InventoryManager>("SELECT Id, Name, CostPrice__c, OwnedPrice__c, RetailCost__c, CurrentInventory__c, InventoryOnOrder__c, SampleInHouse__c FROM Inventory__c").Result.Records;

                return View(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index","InventoryManager");
            }
        }


        public ActionResult ListInventoryPictures()
        {
            try
            {
                var accessToken = Session["AccessToken"].ToString();
                var apiVersion = Session["ApiVersion"].ToString();
                var internalURI = Session["InstanceUrl"].ToString();


                //var client = new ForceClient(apiVersion,internalURI, accessToken);
                var client = new ForceClient(internalURI, accessToken, apiVersion);

                List<InventoryManager> model = client.QueryAsync<InventoryManager>("SELECT Id, Name, CostPrice__c, OwnedPrice__c, RetailCost__c, CurrentInventory__c, InventoryOnOrder__c, SampleInHouse__c, ProductPicture__c FROM Inventory__c").Result.Records;

                return View(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "InventoryManager");
            }

        }

        // GET: InventoryManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InventoryManager/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: InventoryManager/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InventoryManager/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: InventoryManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InventoryManager/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

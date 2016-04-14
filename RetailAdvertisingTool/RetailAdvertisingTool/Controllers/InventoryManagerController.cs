using RetailAdvertisingTool.Models;
using Salesforce.Force;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetailAdvertisingTool.Controllers
{
    public class InventoryManagerController : Controller
    {
        // GET: InventoryManager
        public ActionResult Index()
        {
            return View();
        }

        // GET: InventoryManager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult ListInventory()
        {

            var accessToken = Session["AccessToken"].ToString();
            var apiVersion = Session["ApiVersion"].ToString();
            var internalURI = Session["InstanceUrl"].ToString();


            //var client = new ForceClient(apiVersion,internalURI, accessToken);
            var client = new ForceClient(internalURI, accessToken, apiVersion);

            List<InventoryManager> model = client.QueryAsync<InventoryManager>("SELECT Name, CostPrice__c, OwnedPrice__c, RetailCost__c, CurrentInventory__c, InventoryOnOrder__c, SampleInHouse__c FROM Inventory__c").Result.Records;

            return View(model);
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

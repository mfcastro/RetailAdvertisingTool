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
    public class AdvertisingOfferController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdvertisingOffer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OfferList()
        {
            return View(db.AdvertisingOffer.ToList());
        }

        // GET: AdvertisingOffer/Details/5
        public ActionResult Details(int id)
        {
            AdvertisingOffer offerToView = db.AdvertisingOffer.Where(x => x.Id == id).SingleOrDefault();
            return View(offerToView);
        }

        // GET: AdvertisingOffer/Create
        public ActionResult Create()
        {
            try
            {
                var accessToken = Session["AccessToken"].ToString();
                var apiVersion = Session["ApiVersion"].ToString();
                var internalURI = Session["InstanceUrl"].ToString();

                var client = new ForceClient(internalURI, accessToken, apiVersion);

                AdvertisingOfferCreator model = new AdvertisingOfferCreator();

                model.InventoryManager = client.QueryAsync<InventoryManager>("SELECT Name FROM Inventory__c").Result.Records;

                return View(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "InventoryManager");
            }
           

            

           // return View();
        }

        // POST: AdvertisingOffer/Create
        [HttpPost]
        public ActionResult Create(AdvertisingOffer AdvertisingOffer)
        {

            try
            {
                // TODO: Add insert logic here
                db.AdvertisingOffer.Add(AdvertisingOffer);
                db.SaveChanges();
                return RedirectToAction("OfferList");
                
                // return View("OfferList");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: AdvertisingOffer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdvertisingOffer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                AdvertisingOffer offerToEdit = db.AdvertisingOffer.Where(x => x.Id == id).SingleOrDefault();
                return View(offerToEdit);
                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //// GET: AdvertisingOffer/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: AdvertisingOffer/Delete/5
        //[HttpPost]
        public ActionResult Delete(int id, AdvertisingOffer advertisingOffer)
        {
            try
            {
                AdvertisingOffer offerToRemove = db.AdvertisingOffer.Where(x => x.Id == id).SingleOrDefault();
                // TODO: Add delete logic here
                db.AdvertisingOffer.Remove(offerToRemove);
                db.SaveChanges();
                // return RedirectToAction("");
                return RedirectToAction("OfferList");
            }
            catch
            {
                return View();
            }
        }
    }
}

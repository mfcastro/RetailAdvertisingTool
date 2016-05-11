using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RetailAdvertisingTool.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Salesforce.Force;

namespace RetailAdvertisingTool.Controllers
{
    [Authorize]
    public class EmailFormController : Controller
    {
        // GET: EmailForm
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmailForm/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmailForm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmailForm/Create
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

        // GET: EmailForm/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmailForm/Edit/5
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

        // GET: EmailForm/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmailForm/Delete/5
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


        public ActionResult Contact()
        {
            try
            {
                var accessToken = Session["AccessToken"].ToString();
                var apiVersion = Session["ApiVersion"].ToString();
                var internalURI = Session["InstanceUrl"].ToString();

                var client = new ForceClient(internalURI, accessToken, apiVersion);

                EmailFormObjects model = new EmailFormObjects();

                model.VendorInfo = client.QueryAsync<Vendor>("SELECT Name, Title, Email FROM Contact WHERE Title ='Account Executive'").Result.Records;
                model.InventoryManager = client.QueryAsync<InventoryManager>("SELECT Id, Name, CostPrice__c, OwnedPrice__c, RetailCost__c, CurrentInventory__c, InventoryOnOrder__c, SampleInHouse__c, ProductPicture__c FROM Inventory__c Where SampleInHouse__c = False").Result.Records;

                return View(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "InventoryManager");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<ActionResult> Contact(EmailFormObjects model)
        {
            if (ModelState.IsValid)
            {
                var body = 
                    "<p>Hello,</p>"
                    +"<p>Can you please send the following item.</p>"
                    +"<h2>{2}</h2>"
                    +"<p>Additional comments:</p>"
                    +"<p>{3}</p>"
                    +"<p>Thank you,</p>"
                    +"<p>{0}</p>"
                    +"<p>{1}</p>";


                var message = new MailMessage();
                message.To.Add(new MailAddress(model.EmailForm.VendorEmail));  // replace with valid value 
                message.From = new MailAddress("mfcastro50@outlook.com");  // replace with valid value
                message.Subject = "Sample Requested";
                message.Body = string.Format(body, model.EmailForm.FromName, model.EmailForm.FromEmail, model.EmailForm.ProductName, model.EmailForm.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {

                        UserName = "mfcastro50@outlook.com",
                        Password = "Redzone1?"  //REMOVE BEFORE SENDING TO GIT!!!!
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }

        public ActionResult Sent()
        {
            return View();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RetailAdvertisingTool.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace RetailAdvertisingTool.Controllers
{
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<ActionResult> Contact(EmailForm model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("mfcastro50@gamil.com"));  // replace with valid value 
                message.From = new MailAddress("mfcastro50@outlook.com");  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        //UserName = "user@outlook.com",  // replace with valid value
                        //Password = "password"  // replace with valid value


                        UserName = "example@outlook.com",
                        Password = "Password" 
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

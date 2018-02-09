using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Go_Print_YourSelf.Models;
using System.Net;
using SendGrid;
using System.Net.Mail;


namespace Go_Print_YourSelf.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _ContactForm(ContactForm model)
        {

            if (ModelState.IsValid)
            {
                var body = "Name: {0} <br />  Email: {1} <br /> Website/Facebook: {2} <br />  Company Name: {3} <br /> Position: {4} ";
                var message = new SendGridMessage();
                message.AddTo("connerg@goprintyourself.com");  // replace with valid value 
                message.From = new MailAddress("connerg@goprintyourself.com");  // replace with valid value
                message.Subject = "Go Print Yourself";
                message.Html = string.Format(body, model.FullName, model.Email, model.WebsiteFacebook, model.CompanyName, model.Position);
                //Azure credentials
                var username = "azure_8b8a64638c6bdacad86023f15c2e402b@azure.com";
                var pswd = "Cg090482?";

                // variable to store azure credentials
                var credentials = new NetworkCredential(username, pswd);
                // Create an Web transport for sending email.
                var transportWeb = new Web(credentials);

                // Send the email, which returns an awaitable task.
                transportWeb.DeliverAsync(message);

                ViewBag.Message = "Message Sent";
                ModelState.Clear(); //clears form when page reload
                return View("Index");

            }
            return View(model);
        }
    }
}
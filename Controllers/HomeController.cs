using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using System.Net.Mail;
using MAIL_MVC.Models;

namespace MAIL_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(EmailModel model)
        {
            using (MailMessage mm = new MailMessage(model.Email, model.To))
            {
                mm.Subject = model.Subject;
                mm.Body = model.Body;
                if (model.Attachment.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(model.Attachment.FileName);
                    mm.Attachments.Add(new Attachment(model.Attachment.InputStream, fileName));
                }
                mm.IsBodyHtml = false;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com"; //IP Address
                    smtp.EnableSsl = true; //false
                    NetworkCredential NetworkCred = new NetworkCredential(model.Email, model.Password);
                    //NetworkCredential NetworkCred = new NetworkCredential("Mail ID", "Password");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587; //25
                    //Turn Less Secure apps to "ON" in your Sender Google Account
                    smtp.Send(mm);
                    ViewBag.Message = "Email sent.";
                }
            }

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
    }
}
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BlueMoonAdmin.Models;
using BlueMoonAdmin.Services;
using BlueMoonAdmin.Extensions.Microsoft.AspNetCore.Mvc;
using BlueMoonAdmin.Data;
using BlueMoonAdmin.Utility;
using System.Net.Mail;

namespace BlueMoonAdmin.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        public ContactUsController(

            ApplicationDbContext db,
            IEmailSender emailSender,
            ILogger<ContactUsController> logger)
        {
            _db = db;
            _emailSender = emailSender;
            _logger = logger;
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(Models.ViewModels.ContactUsViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var mail = new MailMessage();
                mail.To.Add(new MailAddress(model.SenderEmail));
                mail.Subject = "Your Email Subject";
                mail.Body = string.Format("<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>", model.SenderName, model.SenderEmail, model.TelephoneNumber, model.Message);
                mail.IsBodyHtml = true;
                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(mail);
                    return RedirectToAction("SuccessMessage");
                }
            }
            return View(model);
        }

        public ActionResult SuccessMessage()
        {
            return View();
        }
    }

}

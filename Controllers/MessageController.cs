using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppTest.Models;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;

namespace WebAppTest.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult GetStatus()
        {
            
            return View();
        }

        public ActionResult Confirmation()
        {

            return View("Confirmation");
        }
        

        [HttpPost]

        public ActionResult EmailCheck()
        {
            string email = Request.Form["Email"];
            if (!ValidateEmail.IsValidEmail(email))
            {
                return Content("Can't send email");  
            }
            
            return Content("true");
        }

        

    }
    public static class ValidateEmail
    {
        public static bool IsValidEmail(this string email)
        {
            Regex r = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            Match match = r.Match(email);

            return !string.IsNullOrEmpty(email) && match.Success;
        }
    }
}
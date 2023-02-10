using AidTurkey.Models;
using AidTurkey.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AidTurkey.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public JsonResult Contact(string name, string company, string email, string message, string messageFrom)
        {
            // accountService.SaveContactData(name, company, email, message,Request.ServerVariables["remote_addr"],messageFrom);
            MailService.SendEmail("oguz@quikmotion.com", "AidTurkey Contact Request",
                "Name:" + name + "<br>" +
                 "Email:" + email + "<br>" +
                "Company:" + company + "<br>" +
                "Message:" + message + "<br>" +
                "Message from:" + messageFrom

                );
            return Json(new { success = true });
        }
    }
}
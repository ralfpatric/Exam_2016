using Exam_2016.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam_2016.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
            // Branch changes ???
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
        
        public ActionResult Chat()
        {
            IEnumerable<Chat> c = db.Chats.ToList();

            return View(c);
        }
    }
}
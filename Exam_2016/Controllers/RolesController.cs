using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Exam_2016.Models;

namespace Exam_2016.Controllers
{
    public class RolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Roles
        public ActionResult Index()
        {
            IEnumerable<CompanyRole> roles = db.CompanyRoles.ToList();
            return View(roles);
        }

        // GET: Roles/Details/5
        public ActionResult Details(int RoleId)
        {
            return View(db.Roles.Find(RoleId));
        }
    }
}

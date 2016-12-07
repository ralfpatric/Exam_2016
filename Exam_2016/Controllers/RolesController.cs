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
        public ActionResult Index(int? id)
        {
            IEnumerable<CompanyRole> roles;
            if (id == null)
            {
                roles = db.CompanyRoles.ToList();
            }
            else
            {
                roles = db.CompanyRoles.ToList().FindAll(i => i.CompanyId == id);
            }
            
            return View(roles);
        }

        // GET: Roles/Details/5
        public ActionResult Details(int? RoleId)
        {
            CompanyRole role;
            if (RoleId == null)
            {
                role = new CompanyRole();
            }
            else
            {
                role = db.CompanyRoles.Find(RoleId);
            }

            return View(role);
        }
    }
}

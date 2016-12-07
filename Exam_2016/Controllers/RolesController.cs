using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Exam_2016.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

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
            IEnumerable<CompanyRole> role;
            if (RoleId == null)
            {
                ViewBag.RoleId = RoleId;
                role = null;
            }
            else
            {
                ViewBag.RoleId = RoleId;
                role = db.CompanyRoles.ToList().FindAll(i => i.CompanyRoleId == RoleId);
            }

            return View(role);
        }

        public ActionResult Create()
        {
            var uid = User.Identity.GetUserId();

            Employee e = db.Employees.Find(uid);
            ViewBag.CurrentCompanyId = e.CompanyId;

            return View();
        }

        public ActionResult AddToPastRoles(int? RoleId)
        {
            if (RoleId != null)
            {
                string sid = User.Identity.GetUserId();

                Employee e = db.Employees.Find(sid);
                IEnumerable<CompanyRole> cr = (IEnumerable<CompanyRole>)db.CompanyRoles.Find(RoleId);
                e.PastRoles = e.PastRoles.Concat(cr);
                db.SaveChanges();
            }

            return RedirectToAction("Details", RoleId);
        }

        public ActionResult AddToCurrentRoles(int? RoleId)
        {
            if (RoleId != null)
            {
                string sid = User.Identity.GetUserId();

                Employee e = db.Employees.Find(sid);
                IEnumerable<CompanyRole> cr = (IEnumerable<CompanyRole>)db.CompanyRoles.Find(RoleId);
                e.CurrentRoles = e.CurrentRoles.Concat(cr);
                db.SaveChanges();
            }

            return RedirectToAction("Details", RoleId);
        }

        public ActionResult AddToFutureRoles(int? RoleId)
        {
            if (RoleId != null)
            {
                string sid = User.Identity.GetUserId();

                Employee e = db.Employees.Find(sid);
                IEnumerable<CompanyRole> cr = (IEnumerable<CompanyRole>)db.CompanyRoles.Find(RoleId);
                e.FutureRoles = e.FutureRoles.Concat(cr);
                db.SaveChanges();
            }

            return RedirectToAction("Details", RoleId);
        }
    }
}

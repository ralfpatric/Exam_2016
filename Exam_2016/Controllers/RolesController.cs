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
        [Authorize]
        public ActionResult Index(int? id)
        {
            RoleIndexViewModel rivm = new RoleIndexViewModel();
            if (id == null)
            {
                var temp = db.Employees.Find(User.Identity.GetUserId()).CompanyId;
                if (temp != null)
                {
                    int CurrentCompanyId = (int)temp;
                    ViewBag.CurrentCompanyName = db.Companies.Find(CurrentCompanyId).Name;

                    rivm.CurrentEmployee = db.Employees.Find(User.Identity.GetUserId());
                    rivm.CurrentCompany = db.Companies.Find(CurrentCompanyId);
                    rivm.CompanyRoles = (List<CompanyRole>)db.Companies.Find(CurrentCompanyId).Roles;
                } else
                {
                    rivm.CurrentEmployee = null;
                    rivm.CurrentCompany = null;
                    rivm.CompanyRoles = null;
                }
            }
            else
            {
                ViewBag.CurrentCompanyName = db.Companies.Find(id).Name;

                rivm.CurrentEmployee = db.Employees.Find(User.Identity.GetUserId());
                rivm.CurrentCompany = db.Companies.Find(id);
                rivm.CompanyRoles = db.CompanyRoles.ToList().FindAll(i => i.CompanyId == id);
            }
            
            return View(rivm);
        }

        // GET: Roles/Details/5
        [Authorize]
        public ActionResult Details(int? RoleId)
        {
            CompanyRole role;
            if (RoleId == null)
            {
                return View("Error");
            }
            else
            {
                role = db.CompanyRoles.Find(RoleId);
                return View(role);
            }
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description")] CompanyRole cr)
        {
            if (ModelState.IsValid)
            {
                string uid = User.Identity.GetUserId();
                Employee e = db.Employees.Find(uid);
                if (e.CompanyId != null)
                {
                    int cid = (int)e.CompanyId;
                    cr.CompanyId = cid;
                    db.CompanyRoles.Add(cr);
                    Company c = db.Companies.Find(cid);
                    c.Roles.Add(cr);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View("Error: You must be in a company to add a role (to a company).");
        }

        public ActionResult AddToPastRoles(int? RoleId)
        {
            if (RoleId != null)
            {
                string sid = User.Identity.GetUserId();

                Employee e = db.Employees.Find(sid);
                CompanyRole cr = (CompanyRole)db.CompanyRoles.Find(RoleId);
                e.PastRoles.Add(cr);
                e.AllRoles.Add(cr);
                cr.Employees.Add(e);
                db.SaveChanges();
            }

            return RedirectToAction("Details", new { RoleId = RoleId });
        }

        public ActionResult AddToCurrentRoles(int? RoleId)
        {
            if (RoleId != null)
            {
                string sid = User.Identity.GetUserId();

                Employee e = db.Employees.Find(sid);
                CompanyRole cr = db.CompanyRoles.Find(RoleId);
                e.CurrentRoles.Add(cr);
                e.AllRoles.Add(cr);
                cr.Employees.Add(e);
                db.SaveChanges();
            }

            return RedirectToAction("Details", new { RoleId = RoleId });
        }

        public ActionResult AddToFutureRoles(int? RoleId)
        {
            if (RoleId != null)
            {
                string sid = User.Identity.GetUserId();

                Employee e = db.Employees.Find(sid);
                CompanyRole cr = (CompanyRole)db.CompanyRoles.Find(RoleId);
                List<CompanyRole> L = e.FutureRoles;
                L.Add(cr);
                e.FutureRoles = L;
                e.AllRoles.Add(cr);
                cr.Employees.Add(e);
                db.SaveChanges();
            }

            return RedirectToAction("Details", new { RoleId = RoleId });
        }

        [HttpPost]
        public ActionResult AddCurriculum(int RoleId, string Curriculum)
        {
            CompanyRole cr = db.CompanyRoles.Find(RoleId);
            Curriculum c = new Curriculum();
            c.CurriculumContent = Curriculum;
            cr.Curriculum.Add(c);
            db.SaveChanges();

            return RedirectToAction("Details", new { RoleId = RoleId });
        }
    }
}

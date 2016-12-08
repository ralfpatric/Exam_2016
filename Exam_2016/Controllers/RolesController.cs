﻿using System;
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
            CompanyRole role;
            if (RoleId == null)
            {
                role = db.CompanyRoles.Find(1);
                return View(role);
            }
            else
            {
                role = db.CompanyRoles.Find(RoleId);
                return View(role);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyId,Name,Description")] CompanyRole cr)
        {
            if (ModelState.IsValid)
            {
                db.CompanyRoles.Add(cr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cr);
        }

        public ActionResult AddToPastRoles(int? RoleId)
        {
            if (RoleId != null)
            {
                string sid = User.Identity.GetUserId();

                Employee e = db.Employees.Find(sid);
                CompanyRole cr = (CompanyRole)db.CompanyRoles.Find(RoleId);
                e.PastRoles.Add(cr);
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
                CompanyRole cr = (CompanyRole)db.CompanyRoles.Find(RoleId);
                e.CurrentRoles.Add(cr);
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
                CompanyRole cr = (CompanyRole)db.CompanyRoles.Find(RoleId);
                e.FutureRoles.Add(cr);
                db.SaveChanges();
            }

            return RedirectToAction("Details", RoleId);
        }

        public ActionResult AddCurriculum(int RoleId, string Curriculum)
        {
            CompanyRole cr = db.CompanyRoles.Find(RoleId);
            cr.Curriculum.Add(Curriculum);
            db.SaveChanges();

            return RedirectToAction("Details", RoleId);
        }
    }
}

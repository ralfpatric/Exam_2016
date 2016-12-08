using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Exam_2016.Models;
using Microsoft.AspNet.Identity;

namespace Exam_2016.Controllers
{
    public class CompanyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Company
        public ActionResult Index()
        {
            return View(new CompanyViewModel
            {
                Companies = db.Companies.ToList(),
                CurrentEmployee = db.Employees.Find(User.Identity.GetUserId())
            });
        }

        // GET: Company/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyId,Name,Logo,NextYearlyInterview")] Company company)
        {
            if (ModelState.IsValid)
            {
                var CurrentUserId = User.Identity.GetUserId();
                company.Admins.Add(CurrentUserId);
                Employee employee = db.Employees.Find(User.Identity.GetUserId());
                company.Employees.Add(employee);

                db.Companies.Add(company);
                db.SaveChanges();

                SetEmployeeToCompany(company.CompanyId);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CurrentCompanyId = company.CompanyId;

            return View(company);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyId,Name,Logo,NextYearlyInterview")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BecomePartOfCompany(int companyId)
        {
            Employee employee = db.Employees.Find(User.Identity.GetUserId());
            Company company = db.Companies.Find(companyId);

            company.Employees.Add(employee);
            db.SaveChanges();
            SetEmployeeToCompany(companyId);
            return RedirectToAction("Index");
        }

        private void SetEmployeeToCompany(int companyId)
        {
            Employee employee = db.Employees.Find(User.Identity.GetUserId());
            employee.CompanyId = companyId;
            this.db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

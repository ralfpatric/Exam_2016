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
using Newtonsoft.Json;
using System.Threading.Tasks;

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
        public ActionResult Create([Bind(Include = "CompanyId,Name,Description,Logo,NextYearlyInterview")] Company company)
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
        public ActionResult Edit([Bind(Include = "CompanyId,Name,Description,Logo,NextYearlyInterview")] Company company)
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
        
        public ActionResult GenerateChart()
        {
            Employee e = db.Employees.Find(User.Identity.GetUserId());
            if (e.CompanyId != null)
            {
                //Fetch employee's company if employee is in a company (companyid is set)
                Company c = db.Companies.Find((int)e.CompanyId);

                //Create a list of employees to contain the employees associated with the company
                List<Employee> le = new List<Models.Employee>();
                foreach(var item in c.Employees)
                {
                    le.Add(item);
                }

                //Create anonymous object, insert company object and the list of employees
                var v = new { Company = c, Employees = le };
                
                //Use JSON.NET to serialize the object to a JSON string. Because we have a many to many relationship, an infinite loop error was thrown
                //The error was handled by having the serializer ignore loops
                //However, as no depth variable was provided for when the serializer starts to ignore loops, it did not include the list at all
                //Because of this, the list is manually created above and an object is created which has the company and its immediate data, and the list of employees (along with their roles)
                string json = JsonConvert.SerializeObject(v, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

                return Json(json);
            }

            return Json(new { id = 2, name = "J" }, JsonRequestBehavior.AllowGet);
        }
    }
}

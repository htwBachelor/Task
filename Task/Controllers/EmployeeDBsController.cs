using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task.Models;

namespace Task.Controllers
{
    public class EmployeeDBsController : Controller
    {
        private STPEntities db = new STPEntities();

        // GET: EmployeeDBs
        public ActionResult Index()
        {
            var employeeDBs = db.EmployeeDBs.Include(e => e.CompaniesDB).Include(e => e.EmplyeeInfoDB);
            return View(employeeDBs.ToList());
        }

        // GET: EmployeeDBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDB employeeDB = db.EmployeeDBs.Find(id);
            if (employeeDB == null)
            {
                return HttpNotFound();
            }
            return View(employeeDB);
        }

        // GET: EmployeeDBs/Create
        public ActionResult Create()
        {
            ViewBag.idCompany = new SelectList(db.CompaniesDBs, "idCompany", "NameCompany");
            ViewBag.IdEmployee = new SelectList(db.EmplyeeInfoDBs, "idInfo", "IdEmloyee");
            return View();
        }

        // POST: EmployeeDBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmployee,FirstName,SecondName,idCompany")] EmployeeDB employeeDB)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeDBs.Add(employeeDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCompany = new SelectList(db.CompaniesDBs, "idCompany", "NameCompany", employeeDB.idCompany);
            ViewBag.IdEmployee = new SelectList(db.EmplyeeInfoDBs, "idInfo", "IdEmloyee", employeeDB.IdEmployee);
            return View(employeeDB);
        }

        // GET: EmployeeDBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDB employeeDB = db.EmployeeDBs.Find(id);
            if (employeeDB == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCompany = new SelectList(db.CompaniesDBs, "idCompany", "NameCompany", employeeDB.idCompany);
            ViewBag.IdEmployee = new SelectList(db.EmplyeeInfoDBs, "idInfo", "IdEmloyee", employeeDB.IdEmployee);
            return View(employeeDB);
        }

        // POST: EmployeeDBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmployee,FirstName,SecondName,idCompany")] EmployeeDB employeeDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCompany = new SelectList(db.CompaniesDBs, "idCompany", "NameCompany", employeeDB.idCompany);
            ViewBag.IdEmployee = new SelectList(db.EmplyeeInfoDBs, "idInfo", "IdEmloyee", employeeDB.IdEmployee);
            return View(employeeDB);
        }

        // GET: EmployeeDBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDB employeeDB = db.EmployeeDBs.Find(id);
            if (employeeDB == null)
            {
                return HttpNotFound();
            }
            return View(employeeDB);
        }

        // POST: EmployeeDBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeDB employeeDB = db.EmployeeDBs.Find(id);
            db.EmployeeDBs.Remove(employeeDB);
            db.SaveChanges();
            return RedirectToAction("Index");
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

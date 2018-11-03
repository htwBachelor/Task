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
    public class EmplyeeInfoDBsController : Controller
    {
        private STPEntities db = new STPEntities();

        // GET: EmplyeeInfoDBs
        public ActionResult Index()
        {
            var emplyeeInfoDBs = db.EmplyeeInfoDBs.Include(e => e.EmployeeDB);
            return View(emplyeeInfoDBs.ToList());
        }

        // GET: EmplyeeInfoDBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmplyeeInfoDB emplyeeInfoDB = db.EmplyeeInfoDBs.Find(id);
            if (emplyeeInfoDB == null)
            {
                return HttpNotFound();
            }
            return View(emplyeeInfoDB);
        }

        // GET: EmplyeeInfoDBs/Create
        public ActionResult Create()
        {
            ViewBag.idInfo = new SelectList(db.EmployeeDBs, "IdEmployee", "FirstName");
            return View();
        }

        // POST: EmplyeeInfoDBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idInfo,IdEmloyee,ExpLevel,StartingDate,Salary,VacationDay")] EmplyeeInfoDB emplyeeInfoDB)
        {
            if (ModelState.IsValid)
            {
                db.EmplyeeInfoDBs.Add(emplyeeInfoDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idInfo = new SelectList(db.EmployeeDBs, "IdEmployee", "FirstName", emplyeeInfoDB.idInfo);
            return View(emplyeeInfoDB);
        }

        // GET: EmplyeeInfoDBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmplyeeInfoDB emplyeeInfoDB = db.EmplyeeInfoDBs.Find(id);
            if (emplyeeInfoDB == null)
            {
                return HttpNotFound();
            }
            ViewBag.idInfo = new SelectList(db.EmployeeDBs, "IdEmployee", "FirstName", emplyeeInfoDB.idInfo);
            return View(emplyeeInfoDB);
        }

        // POST: EmplyeeInfoDBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idInfo,IdEmloyee,ExpLevel,StartingDate,Salary,VacationDay")] EmplyeeInfoDB emplyeeInfoDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emplyeeInfoDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idInfo = new SelectList(db.EmployeeDBs, "IdEmployee", "FirstName", emplyeeInfoDB.idInfo);
            return View(emplyeeInfoDB);
        }

        // GET: EmplyeeInfoDBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmplyeeInfoDB emplyeeInfoDB = db.EmplyeeInfoDBs.Find(id);
            if (emplyeeInfoDB == null)
            {
                return HttpNotFound();
            }
            return View(emplyeeInfoDB);
        }

        // POST: EmplyeeInfoDBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmplyeeInfoDB emplyeeInfoDB = db.EmplyeeInfoDBs.Find(id);
            db.EmplyeeInfoDBs.Remove(emplyeeInfoDB);
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

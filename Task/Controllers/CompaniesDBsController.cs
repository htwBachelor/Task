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
    public class CompaniesDBsController : Controller
    {
        private STPEntities db = new STPEntities();

        // GET: CompaniesDBs
        public ActionResult Index()
        {
            return View(db.CompaniesDBs.ToList());
        }

        // GET: CompaniesDBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompaniesDB companiesDB = db.CompaniesDBs.Find(id);
            if (companiesDB == null)
            {
                return HttpNotFound();
            }
            return View(companiesDB);
        }

        // GET: CompaniesDBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompaniesDBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCompany,NameCompany,Inforamtion")] CompaniesDB companiesDB)
        {
            if (ModelState.IsValid)
            {
                db.CompaniesDBs.Add(companiesDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companiesDB);
        }

        // GET: CompaniesDBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompaniesDB companiesDB = db.CompaniesDBs.Find(id);
            if (companiesDB == null)
            {
                return HttpNotFound();
            }
            return View(companiesDB);
        }

        // POST: CompaniesDBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCompany,NameCompany,Inforamtion")] CompaniesDB companiesDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companiesDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companiesDB);
        }

        // GET: CompaniesDBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompaniesDB companiesDB = db.CompaniesDBs.Find(id);
            if (companiesDB == null)
            {
                return HttpNotFound();
            }
            return View(companiesDB);
        }

        // POST: CompaniesDBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompaniesDB companiesDB = db.CompaniesDBs.Find(id);
            db.CompaniesDBs.Remove(companiesDB);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webapptesting.Models;

namespace webapptesting.Controllers
{
    public class authordatasController : Controller
    {
        private BookimanEntities db = new BookimanEntities();

        // GET: authordatas
        public ActionResult Index()
        {
            return View(db.authordatas.ToList());
        }

        // GET: authordatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            authordata authordata = db.authordatas.Find(id);
            if (authordata == null)
            {
                return HttpNotFound();
            }
            return View(authordata);
        }

        // GET: authordatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: authordatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Author_ID,Created_Date,Updated_Date,Is_Discontinued,Author_Name")] authordata authordata)
        {
            if (ModelState.IsValid)
            {
                db.authordatas.Add(authordata);
                TempData["AlertMessage1"] = "Author added sucessfully..";
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(authordata);
        }

        // GET: authordatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            authordata authordata = db.authordatas.Find(id);
            if (authordata == null)
            {
                return HttpNotFound();
            }
            return View(authordata);
        }

        // POST: authordatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Author_ID,Created_Date,Updated_Date,Is_Discontinued,Author_Name")] authordata authordata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(authordata).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage1"] = "Author details edited sucessfully..";
                return RedirectToAction("Index");
            }
            return View(authordata);
        }

        // GET: authordatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            authordata authordata = db.authordatas.Find(id);
            if (authordata == null)
            {
                return HttpNotFound();
            }
            return View(authordata);
        }

        // POST: authordatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            authordata authordata = db.authordatas.Find(id);
            db.authordatas.Remove(authordata);
            db.SaveChanges();
            TempData["AlertMessage"] = "Author data deleted sucessfully..";
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

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
    public class bookdatasController : Controller
    {
        private BookimanEntities db = new BookimanEntities();

        // GET: bookdatas
        public ActionResult Index()
        {
            var bookdatas = db.bookdatas.Include(b => b.authordata);
            return View(bookdatas.ToList());
        }

        // GET: bookdatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookdata bookdata = db.bookdatas.Find(id);
            if (bookdata == null)
            {
                return HttpNotFound();
            }
            return View(bookdata);
        }

        // GET: bookdatas/Create
        public ActionResult Create()
        {
            ViewBag.Author_ID = new SelectList(db.authordatas, "Author_ID", "Author_Name");
            return View();
        }

        // POST: bookdatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Book_ID,Book_Title,Book_Description,Price,Author_ID")] bookdata bookdata)
        {
            if (ModelState.IsValid)
            {
                db.bookdatas.Add(bookdata);
                db.SaveChanges();
                TempData["AlertMessage"] = "Product added sucessfully..";
                return RedirectToAction("Index");
            }

            ViewBag.Author_ID = new SelectList(db.authordatas, "Author_ID", "Author_Name", bookdata.Author_ID);
            return View(bookdata);
        }

        // GET: bookdatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookdata bookdata = db.bookdatas.Find(id);
            if (bookdata == null)
            {
                return HttpNotFound();
            }
            ViewBag.Author_ID = new SelectList(db.authordatas, "Author_ID", "Author_Name", bookdata.Author_ID);
            return View(bookdata);
        }

        // POST: bookdatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Book_ID,Book_Title,Book_Description,Price,Author_ID")] bookdata bookdata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookdata).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage"] = "Product edited sucessfully..";
                return RedirectToAction("Index");
            }
            ViewBag.Author_ID = new SelectList(db.authordatas, "Author_ID", "Author_Name", bookdata.Author_ID);
            return View(bookdata);
        }

        // GET: bookdatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookdata bookdata = db.bookdatas.Find(id);
            if (bookdata == null)
            {
                return HttpNotFound();
            }
            return View(bookdata);
        }

        // POST: bookdatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bookdata bookdata = db.bookdatas.Find(id);
            db.bookdatas.Remove(bookdata);
            db.SaveChanges();
            TempData["AlertMessage"] = "Product deleted sucessfully..";
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

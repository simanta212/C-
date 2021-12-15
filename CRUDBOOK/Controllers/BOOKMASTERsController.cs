using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDBOOK.Models;

namespace CRUDBOOK.Controllers
{
    public class BOOKMASTERsController : Controller
    {
        private MVC_DatabaseEntities db = new MVC_DatabaseEntities();

        // GET: BOOKMASTERs
        public ActionResult Index()
        {
            return View(db.BOOKMASTERs.ToList());
        }

        // GET: BOOKMASTERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOKMASTER bOOKMASTER = db.BOOKMASTERs.Find(id);
            if (bOOKMASTER == null)
            {
                return HttpNotFound();
            }
            return View(bOOKMASTER);
        }

        // GET: BOOKMASTERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BOOKMASTERs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BookTitle,BookDescription")] BOOKMASTER bOOKMASTER)
        {
            if (ModelState.IsValid)
            {
                db.BOOKMASTERs.Add(bOOKMASTER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bOOKMASTER);
        }

        // GET: BOOKMASTERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOKMASTER bOOKMASTER = db.BOOKMASTERs.Find(id);
            if (bOOKMASTER == null)
            {
                return HttpNotFound();
            }
            return View(bOOKMASTER);
        }

        // POST: BOOKMASTERs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BookTitle,BookDescription")] BOOKMASTER bOOKMASTER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bOOKMASTER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bOOKMASTER);
        }

        // GET: BOOKMASTERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOKMASTER bOOKMASTER = db.BOOKMASTERs.Find(id);
            if (bOOKMASTER == null)
            {
                return HttpNotFound();
            }
            return View(bOOKMASTER);
        }

        // POST: BOOKMASTERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BOOKMASTER bOOKMASTER = db.BOOKMASTERs.Find(id);
            db.BOOKMASTERs.Remove(bOOKMASTER);
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

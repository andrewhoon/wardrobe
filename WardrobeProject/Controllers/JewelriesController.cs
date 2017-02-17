using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WardrobeProject.Models;

namespace WardrobeProject.Controllers
{
    public class JewelriesController : Controller
    {
        private WardrobeProjectEntities db = new WardrobeProjectEntities();

        // GET: Jewelries
        public ActionResult Index()
        {
            return View(db.Jewelries.ToList());
        }

        // GET: Jewelries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jewelries jewelries = db.Jewelries.Find(id);
            if (jewelries == null)
            {
                return HttpNotFound();
            }

            ViewBag.Photo = jewelries.JPhoto;




            return View(jewelries);
        }

        // GET: Jewelries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jewelries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JewelriesID,JName,JType,JMetal,JOccasion,JPhoto")] Jewelries jewelries)
        {
            if (ModelState.IsValid)
            {
                db.Jewelries.Add(jewelries);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jewelries);
        }

        // GET: Jewelries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jewelries jewelries = db.Jewelries.Find(id);
            if (jewelries == null)
            {
                return HttpNotFound();
            }
            return View(jewelries);
        }

        // POST: Jewelries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JewelriesID,JName,JType,JMetal,JOccasion,JPhoto")] Jewelries jewelries)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jewelries).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jewelries);
        }

        // GET: Jewelries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jewelries jewelries = db.Jewelries.Find(id);
            if (jewelries == null)
            {
                return HttpNotFound();
            }
            return View(jewelries);
        }

        // POST: Jewelries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jewelries jewelries = db.Jewelries.Find(id);
            db.Jewelries.Remove(jewelries);
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

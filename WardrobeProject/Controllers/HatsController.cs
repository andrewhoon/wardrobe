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
    public class HatsController : Controller
    {
        private WardrobeProjectEntities db = new WardrobeProjectEntities();

        // GET: Hats
        public ActionResult Index()
        {
            return View(db.Hats.ToList());
        }

        // GET: Hats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hats hats = db.Hats.Find(id);
            if (hats == null)
            {
                return HttpNotFound();
            }
            return View(hats);
        }

        // GET: Hats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HatsID,HatsName,HatsType,HatsColor,HatsSeason,HatsOccasion,HatsPhoto")] Hats hats)
        {
            if (ModelState.IsValid)
            {
                db.Hats.Add(hats);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hats);
        }

        // GET: Hats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hats hats = db.Hats.Find(id);
            if (hats == null)
            {
                return HttpNotFound();
            }
            return View(hats);
        }

        // POST: Hats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HatsID,HatsName,HatsType,HatsColor,HatsSeason,HatsOccasion,HatsPhoto")] Hats hats)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hats).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hats);
        }

        // GET: Hats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hats hats = db.Hats.Find(id);
            if (hats == null)
            {
                return HttpNotFound();
            }
            return View(hats);
        }

        // POST: Hats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hats hats = db.Hats.Find(id);
            db.Hats.Remove(hats);
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

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
    public class TopsController : Controller
    {
        private WardrobeProjectEntities db = new WardrobeProjectEntities();

        // GET: Tops
        public ActionResult Index()
        {
            return View(db.Tops.ToList());
        }

        // GET: Tops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tops tops = db.Tops.Find(id);
            if (tops == null)
            {
                return HttpNotFound();
            }
            return View(tops);
        }

        // GET: Tops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TopID,TopName,TopType,TopColor,TopSeason,TopOccasion,TopPhoto")] Tops tops)
        {
            if (ModelState.IsValid)
            {
                db.Tops.Add(tops);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tops);
        }

        // GET: Tops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tops tops = db.Tops.Find(id);
            if (tops == null)
            {
                return HttpNotFound();
            }
            return View(tops);
        }

        // POST: Tops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TopID,TopName,TopType,TopColor,TopSeason,TopOccasion,TopPhoto")] Tops tops)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tops).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tops);
        }

        // GET: Tops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tops tops = db.Tops.Find(id);
            if (tops == null)
            {
                return HttpNotFound();
            }
            return View(tops);
        }

        // POST: Tops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tops tops = db.Tops.Find(id);
            db.Tops.Remove(tops);
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

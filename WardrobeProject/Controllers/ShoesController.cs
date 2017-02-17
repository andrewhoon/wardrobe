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
    public class ShoesController : Controller
    {
        private WardrobeProjectEntities db = new WardrobeProjectEntities();

        // GET: Shoes
        public ActionResult Index()
        {
            return View(db.Shoes.ToList());
        }

        // GET: Shoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shoes shoes = db.Shoes.Find(id);
            if (shoes == null)
            {
                return HttpNotFound();
            }
            return View(shoes);
        }

        // GET: Shoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShoesID,ShoesName,ShoesType,ShoesColor,ShoesSeason,ShoesOccasion,ShoesPhoto")] Shoes shoes)
        {
            if (ModelState.IsValid)
            {
                db.Shoes.Add(shoes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoes);
        }

        // GET: Shoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shoes shoes = db.Shoes.Find(id);
            if (shoes == null)
            {
                return HttpNotFound();
            }
            return View(shoes);
        }

        // POST: Shoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShoesID,ShoesName,ShoesType,ShoesColor,ShoesSeason,ShoesOccasion,ShoesPhoto")] Shoes shoes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoes);
        }

        // GET: Shoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shoes shoes = db.Shoes.Find(id);
            if (shoes == null)
            {
                return HttpNotFound();
            }
            return View(shoes);
        }

        // POST: Shoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shoes shoes = db.Shoes.Find(id);
            db.Shoes.Remove(shoes);
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

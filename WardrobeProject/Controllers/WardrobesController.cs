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
    public class WardrobesController : Controller
    {
        private WardrobeProjectEntities db = new WardrobeProjectEntities();

        // GET: Wardrobes
        public ActionResult Index()
        {
            var wardrobes = db.Wardrobes.Include(w => w.Accessories.Jewelries).Include(w => w.Accessories.Hats).Include(w => w.Bottoms).Include(w => w.Shoes).Include(w => w.Tops);
            return View(wardrobes.ToList());
        }

        // GET: Wardrobes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wardrobes wardrobes = db.Wardrobes.Find(id);
            if (wardrobes == null)
            {
                return HttpNotFound();
            }
            return View(wardrobes);
        }

        // GET: Wardrobes/Create
        public ActionResult Create()
        {
            ViewBag.AccessoriesID = new SelectList(db.Accessories, "AccessoriesID", "AccessoriesID");
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "BottomName");
            ViewBag.ShoesID = new SelectList(db.Shoes, "ShoesID", "ShoesName");
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "TopName");
            return View();
        }

        // POST: Wardrobes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WardrobeID,TopID,BottomID,ShoesID,AccessoriesID")] Wardrobes wardrobes)
        {
            if (ModelState.IsValid)
            {
                db.Wardrobes.Add(wardrobes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccessoriesID = new SelectList(db.Accessories, "AccessoriesID", "AccessoriesID", wardrobes.AccessoriesID);
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "BottomName", wardrobes.BottomID);
            ViewBag.ShoesID = new SelectList(db.Shoes, "ShoesID", "ShoesName", wardrobes.ShoesID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "TopName", wardrobes.TopID);
            return View(wardrobes);
        }

        // GET: Wardrobes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wardrobes wardrobes = db.Wardrobes.Find(id);
            if (wardrobes == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccessoriesID = new SelectList(db.Accessories, "AccessoriesID", "AccessoriesID", wardrobes.AccessoriesID);
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "BottomName", wardrobes.BottomID);
            ViewBag.ShoesID = new SelectList(db.Shoes, "ShoesID", "ShoesName", wardrobes.ShoesID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "TopName", wardrobes.TopID);
            return View(wardrobes);
        }

        // POST: Wardrobes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WardrobeID,TopID,BottomID,ShoesID,AccessoriesID")] Wardrobes wardrobes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wardrobes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccessoriesID = new SelectList(db.Accessories, "AccessoriesID", "AccessoriesID", wardrobes.AccessoriesID);
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "BottomName", wardrobes.BottomID);
            ViewBag.ShoesID = new SelectList(db.Shoes, "ShoesID", "ShoesName", wardrobes.ShoesID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "TopName", wardrobes.TopID);
            return View(wardrobes);
        }

        // GET: Wardrobes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wardrobes wardrobes = db.Wardrobes.Find(id);
            if (wardrobes == null)
            {
                return HttpNotFound();
            }
            return View(wardrobes);
        }

        // POST: Wardrobes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wardrobes wardrobes = db.Wardrobes.Find(id);
            db.Wardrobes.Remove(wardrobes);
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

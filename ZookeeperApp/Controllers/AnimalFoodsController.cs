using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZookeeperApp.Models;

namespace ZookeeperApp.Controllers
{
    [Authorize]
    public class AnimalFoodsController : Controller
    {
        private ZooDBContext db = new ZooDBContext();

        // GET: AnimalFoods
        public ActionResult Index()
        {
            return View(db.AnimalFoods.ToList());
        }

        // GET: AnimalFoods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalFood animalFood = db.AnimalFoods.Find(id);
            if (animalFood == null)
            {
                return HttpNotFound();
            }
            return View(animalFood);
        }

        // GET: AnimalFoods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnimalFoods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FoodName,FoodPrice,TotalQuantity,TotalPrice")] AnimalFood animalFood)
        {
            if (ModelState.IsValid)
            {
                db.AnimalFoods.Add(animalFood);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(animalFood);
        }

        // GET: AnimalFoods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalFood animalFood = db.AnimalFoods.Find(id);
            if (animalFood == null)
            {
                return HttpNotFound();
            }
            return View(animalFood);
        }

        // POST: AnimalFoods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FoodName,FoodPrice,TotalQuantity,TotalPrice")] AnimalFood animalFood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animalFood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(animalFood);
        }

        // GET: AnimalFoods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalFood animalFood = db.AnimalFoods.Find(id);
            if (animalFood == null)
            {
                return HttpNotFound();
            }
            return View(animalFood);
        }

        // POST: AnimalFoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnimalFood animalFood = db.AnimalFoods.Find(id);
            db.AnimalFoods.Remove(animalFood);
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

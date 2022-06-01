using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicStore.Domain.Concrete;
using MusicStore.Domain.Entities;

namespace MusicStore.WebUI.Controllers
{
    public class ShippingDetailsController : Controller
    {
        private MusicStoreContext db = new MusicStoreContext();

        // GET: ShippingDetails
        public ActionResult Index()
        {
            return View(db.ShippingDetails.ToList());
        }

        // GET: ShippingDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingDetails shippingDetails = db.ShippingDetails.Find(id);

            if (shippingDetails == null)
            {
                return HttpNotFound();
            }
            return View(db.Orders.Where(x => x.ShippingDetailsId == shippingDetails.ShippingDetailsId).ToList());
        }

        // GET: ShippingDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShippingDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShippingDetailsId,Name,PhoneNumber,Email,Line1,City,Country")] ShippingDetails shippingDetails)
        {
            if (ModelState.IsValid)
            {
                db.ShippingDetails.Add(shippingDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shippingDetails);
        }

        // GET: ShippingDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingDetails shippingDetails = db.ShippingDetails.Find(id);
            if (shippingDetails == null)
            {
                return HttpNotFound();
            }
            return View(shippingDetails);
        }

        // POST: ShippingDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShippingDetailsId,Name,PhoneNumber,Email,Line1,City,Country")] ShippingDetails shippingDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shippingDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shippingDetails);
        }

        // GET: ShippingDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingDetails shippingDetails = db.ShippingDetails.Find(id);
            if (shippingDetails == null)
            {
                return HttpNotFound();
            }
            return View(shippingDetails);
        }

        // POST: ShippingDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShippingDetails shippingDetails = db.ShippingDetails.Find(id);
            db.ShippingDetails.Remove(shippingDetails);
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

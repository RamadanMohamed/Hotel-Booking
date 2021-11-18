using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Divers_Hotel.Models;

namespace Divers_Hotel.Controllers
{
    public class Room_UsageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Room_Usage
        public ActionResult Index()
        {
            return View(db.Room_Usage.ToList());
        }

        // GET: Room_Usage/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room_Usage room_Usage = db.Room_Usage.Find(id);
            if (room_Usage == null)
            {
                return HttpNotFound();
            }
            return View(room_Usage);
        }

        // GET: Room_Usage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Room_Usage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Room_Id,Guest_Id,Hours,Checkin,Date")] Room_Usage room_Usage)
        {
            if (ModelState.IsValid)
            {
                db.Room_Usage.Add(room_Usage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(room_Usage);
        }

        // GET: Room_Usage/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room_Usage room_Usage = db.Room_Usage.Find(id);
            if (room_Usage == null)
            {
                return HttpNotFound();
            }
            return View(room_Usage);
        }

        // POST: Room_Usage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Room_Id,Guest_Id,Hours,Checkin,Date")] Room_Usage room_Usage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room_Usage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(room_Usage);
        }

        // GET: Room_Usage/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room_Usage room_Usage = db.Room_Usage.Find(id);
            if (room_Usage == null)
            {
                return HttpNotFound();
            }
            return View(room_Usage);
        }

        // POST: Room_Usage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room_Usage room_Usage = db.Room_Usage.Find(id);
            db.Room_Usage.Remove(room_Usage);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tickets.Models;

namespace Tickets.Controllers
{
    public class Ticket_StatusController : Controller
    {
        private Ticket_AmandaDEntities db = new Ticket_AmandaDEntities();

        // GET: Ticket_Status
        public ActionResult Index()
        {
            return View(db.Ticket_Status.ToList());
        }

        // GET: Ticket_Status/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket_Status ticket_Status = db.Ticket_Status.Find(id);
            if (ticket_Status == null)
            {
                return HttpNotFound();
            }
            return View(ticket_Status);
        }

        // GET: Ticket_Status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ticket_Status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Status_Id,Status")] Ticket_Status ticket_Status)
        {
            if (ModelState.IsValid)
            {
                db.Ticket_Status.Add(ticket_Status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ticket_Status);
        }

        // GET: Ticket_Status/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket_Status ticket_Status = db.Ticket_Status.Find(id);
            if (ticket_Status == null)
            {
                return HttpNotFound();
            }
            return View(ticket_Status);
        }

        // POST: Ticket_Status/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Status_Id,Status")] Ticket_Status ticket_Status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket_Status).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticket_Status);
        }

        // GET: Ticket_Status/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket_Status ticket_Status = db.Ticket_Status.Find(id);
            if (ticket_Status == null)
            {
                return HttpNotFound();
            }
            return View(ticket_Status);
        }

        // POST: Ticket_Status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket_Status ticket_Status = db.Ticket_Status.Find(id);
            db.Ticket_Status.Remove(ticket_Status);
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

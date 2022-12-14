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
    public class Ticket_DescriptionController : Controller
    {
        private Ticket_AmandaDEntities db = new Ticket_AmandaDEntities();

        // GET: Ticket_Description
        public ActionResult Index()
        {
            return View(db.Ticket_Description.ToList());
        }

        // GET: Ticket_Description/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket_Description ticket_Description = db.Ticket_Description.Find(id);
            if (ticket_Description == null)
            {
                return HttpNotFound();
            }
            return View(ticket_Description);
        }

        // GET: Ticket_Description/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ticket_Description/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Descript_Id,Description")] Ticket_Description ticket_Description)
        {
            if (ModelState.IsValid)
            {
                db.Ticket_Description.Add(ticket_Description);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ticket_Description);
        }

        // GET: Ticket_Description/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket_Description ticket_Description = db.Ticket_Description.Find(id);
            if (ticket_Description == null)
            {
                return HttpNotFound();
            }
            return View(ticket_Description);
        }

        // POST: Ticket_Description/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Descript_Id,Description")] Ticket_Description ticket_Description)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket_Description).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticket_Description);
        }

        // GET: Ticket_Description/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket_Description ticket_Description = db.Ticket_Description.Find(id);
            if (ticket_Description == null)
            {
                return HttpNotFound();
            }
            return View(ticket_Description);
        }

        // POST: Ticket_Description/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket_Description ticket_Description = db.Ticket_Description.Find(id);
            db.Ticket_Description.Remove(ticket_Description);
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

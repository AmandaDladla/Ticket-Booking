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
    public class TicketsController : Controller
    {
        private Ticket_AmandaDEntities db = new Ticket_AmandaDEntities();

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = db.Tickets.Include(t => t.Ticket_Description).Include(t => t.Ticket_Message).Include(t => t.Ticket_Status);
            return View(tickets.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.Descript_Id = new SelectList(db.Ticket_Description, "Descript_Id", "Description");
            ViewBag.Msg_Id = new SelectList(db.Ticket_Message, "Msg_Id", "Message");
            ViewBag.Status_Id = new SelectList(db.Ticket_Status, "Status_Id", "Status");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ticket_Id,Request_Date,Status_Id,Msg_Id,Descript_Id")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Descript_Id = new SelectList(db.Ticket_Description, "Descript_Id", "Description", ticket.Descript_Id);
            ViewBag.Msg_Id = new SelectList(db.Ticket_Message, "Msg_Id", "Message", ticket.Msg_Id);
            ViewBag.Status_Id = new SelectList(db.Ticket_Status, "Status_Id", "Status", ticket.Status_Id);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.Descript_Id = new SelectList(db.Ticket_Description, "Descript_Id", "Description", ticket.Descript_Id);
            ViewBag.Msg_Id = new SelectList(db.Ticket_Message, "Msg_Id", "Message", ticket.Msg_Id);
            ViewBag.Status_Id = new SelectList(db.Ticket_Status, "Status_Id", "Status", ticket.Status_Id);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ticket_Id,Request_Date,Status_Id,Msg_Id,Descript_Id")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Descript_Id = new SelectList(db.Ticket_Description, "Descript_Id", "Description", ticket.Descript_Id);
            ViewBag.Msg_Id = new SelectList(db.Ticket_Message, "Msg_Id", "Message", ticket.Msg_Id);
            ViewBag.Status_Id = new SelectList(db.Ticket_Status, "Status_Id", "Status", ticket.Status_Id);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
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

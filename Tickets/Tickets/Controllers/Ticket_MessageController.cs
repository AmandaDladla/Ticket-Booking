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
    public class Ticket_MessageController : Controller
    {
        private Ticket_AmandaDEntities db = new Ticket_AmandaDEntities();

        // GET: Ticket_Message
        public ActionResult Index()
        {
            var ticket_Message = db.Ticket_Message.Include(t => t.Admin).Include(t => t.User);
            return View(ticket_Message.ToList());
        }

        // GET: Ticket_Message/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket_Message ticket_Message = db.Ticket_Message.Find(id);
            if (ticket_Message == null)
            {
                return HttpNotFound();
            }
            return View(ticket_Message);
        }

        // GET: Ticket_Message/Create
        public ActionResult Create()
        {
            ViewBag.Admin_Id = new SelectList(db.Admins, "Admin_Id", "Name");
            ViewBag.User_Id = new SelectList(db.Users, "User_Id", "Fullname");
            return View();
        }

        // POST: Ticket_Message/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Msg_Id,User_Id,Admin_Id,Message")] Ticket_Message ticket_Message)
        {
            if (ModelState.IsValid)
            {
                db.Ticket_Message.Add(ticket_Message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Admin_Id = new SelectList(db.Admins, "Admin_Id", "Name", ticket_Message.Admin_Id);
            ViewBag.User_Id = new SelectList(db.Users, "User_Id", "Fullname", ticket_Message.User_Id);
            return View(ticket_Message);
        }

        // GET: Ticket_Message/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket_Message ticket_Message = db.Ticket_Message.Find(id);
            if (ticket_Message == null)
            {
                return HttpNotFound();
            }
            ViewBag.Admin_Id = new SelectList(db.Admins, "Admin_Id", "Name", ticket_Message.Admin_Id);
            ViewBag.User_Id = new SelectList(db.Users, "User_Id", "Fullname", ticket_Message.User_Id);
            return View(ticket_Message);
        }

        // POST: Ticket_Message/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Msg_Id,User_Id,Admin_Id,Message")] Ticket_Message ticket_Message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket_Message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Admin_Id = new SelectList(db.Admins, "Admin_Id", "Name", ticket_Message.Admin_Id);
            ViewBag.User_Id = new SelectList(db.Users, "User_Id", "Fullname", ticket_Message.User_Id);
            return View(ticket_Message);
        }

        // GET: Ticket_Message/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket_Message ticket_Message = db.Ticket_Message.Find(id);
            if (ticket_Message == null)
            {
                return HttpNotFound();
            }
            return View(ticket_Message);
        }

        // POST: Ticket_Message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket_Message ticket_Message = db.Ticket_Message.Find(id);
            db.Ticket_Message.Remove(ticket_Message);
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

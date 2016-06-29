using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sparker.Web.Helpers;
using Sparker.Web.Constants;
using Sparker.Web.Models;

namespace Sparker.Web.Controllers
{
    public class EventsController : Controller
    {
        private JsonHelper jsonHelper = new JsonHelper(ApiConstants.SparkerApiBaseUrl);

        // GET: Events
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            Msp msp = (Session[SessionConstants.MspSessionKey] as Msp);
            var events = await jsonHelper.Get<IEnumerable<Event>>("Events/Region/" + msp.RegionId);
            return View(events);
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = null;
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Create([Bind(Include = "Name")] Event @event)
        {
            if (ModelState.IsValid)
            {
                @event.MspId = (Session[SessionConstants.MspSessionKey] as Msp).Id;
                Event e = await jsonHelper.Post("Events/Create", @event);
                if (e != null)
                {
                    return RedirectToAction("Index", "EventDetails");
                }
                else
                    return View();
            }
            
            return View(@event);
        }

        // GET: Events/Edit/5
        public async System.Threading.Tasks.Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = await jsonHelper.Get<Event>("Events/" + id);
            if (@event == null)
            {
                return HttpNotFound();
            }

            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Edit([Bind(Include = "Id,Name,MspId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                Event e = await jsonHelper.Put("Events/" + @event.Id, @event);
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = null;
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Event @event = db.Events.Find(id);
            //db.Events.Remove(@event);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

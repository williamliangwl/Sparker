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
using System.Threading.Tasks;
using Sparker.Web.Models;

namespace Sparker.Web.Controllers
{
    public class EventDetailsController : Controller
    {
        private JsonHelper jsonHelper = new JsonHelper(ApiConstants.SparkerApiBaseUrl);

        // GET: EventDetails
        [Route("EventDetails/{eventId}")]
        [HttpGet]
        public async Task<ActionResult> Index(int eventId)
        {
            var eventDetails = await jsonHelper.Get<IEnumerable<EventDetail>>("EventDetails/Event/" + eventId);
            return View(eventDetails);
        }

        // GET: EventDetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDetail eventDetail = await jsonHelper.Get<EventDetail>("EventDetails/" + id);
            if (eventDetail == null)
            {
                return HttpNotFound();
            }
            return View(eventDetail);
        }

        // GET: EventDetails/Create
        [Route("EventDetails/Create/{eventId}")]
        [HttpGet]
        public ActionResult Create(int eventId)
        {
            ViewBag.EventId = eventId;
            return View();
        }

        // POST: EventDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,DateTime,EventId,UniversityId")] EventDetail eventDetail)
        {
            if (ModelState.IsValid)
            {
                EventDetail result = await jsonHelper.Post("EventDetails", eventDetail);
                return RedirectToAction("Index");
            }

            ViewBag.EventId = eventDetail.EventId;
            //ViewBag.UniversityId = new SelectList(db.Universities, "Id", "Name", eventDetail.UniversityId);
            return View(eventDetail);
        }

        // GET: EventDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDetail eventDetail = null;
            if (eventDetail == null)
            {
                return HttpNotFound();
            }
            //ViewBag.EventId = new SelectList(db.Events, "Id", "Name", eventDetail.EventId);
            //ViewBag.UniversityId = new SelectList(db.Universities, "Id", "Name", eventDetail.UniversityId);
            return View(eventDetail);
        }

        // POST: EventDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DateTime,EventId,UniversityId")] EventDetail eventDetail)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(eventDetail).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.EventId = new SelectList(db.Events, "Id", "Name", eventDetail.EventId);
            //ViewBag.UniversityId = new SelectList(db.Universities, "Id", "Name", eventDetail.UniversityId);
            return View(eventDetail);
        }

        // GET: EventDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDetail eventDetail = null;
            if (eventDetail == null)
            {
                return HttpNotFound();
            }
            return View(eventDetail);
        }

        // POST: EventDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //EventDetail eventDetail = db.EventDetails.Find(id);
            //db.EventDetails.Remove(eventDetail);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sparker.Data.Access;
using Sparker.Data.Models;
using Sparker.Web.Helpers;
using Sparker.Web.Constants;
using System.Threading.Tasks;

namespace Sparker.Web.Controllers
{
    public class MspsController : Controller
    {
        private JsonHelper JsonHelper = new JsonHelper(ApiConstants.AttendanceApiBaseUrl);

        // GET: Msps
        public async Task<ActionResult> Index()
        {
            var msps = await JsonHelper.Get<IEnumerable<Msp>>("Msps/");
            return View(msps);
        }

        // GET: Msps/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Msp msp = await JsonHelper.Get<Msp>("Msps/" + id);
            if (msp == null)
            {
                return HttpNotFound();
            }
            return View(msp);
        }

        // GET: Msps/Create
        public async Task<ActionResult> Create()
        {
            IEnumerable<Region> regions = await JsonHelper.Get<IEnumerable<Region>>("Regions/");
            ViewBag.RegionId = new SelectList(regions, "Id", "Name");
            return View();
        }

        // POST: Msps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,Password,Role,RegionId")] Msp msp)
        {
            if (ModelState.IsValid)
            {
                //db.Msps.Add(msp);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name", msp.RegionId);
            return View(msp);
        }

        // GET: Msps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Msp msp = db.Msps.Find(id);
            //if (msp == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name", msp.RegionId);
            //return View(msp);
            return View();
        }

        // POST: Msps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,Password,Role,RegionId")] Msp msp)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(msp).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name", msp.RegionId);
            return View(msp);
        }

        // GET: Msps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Msp msp = db.Msps.Find(id);
            //if (msp == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(msp);
            return View();
        }

        // POST: Msps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Msp msp = db.Msps.Find(id);
            //db.Msps.Remove(msp);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

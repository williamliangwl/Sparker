using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Sparker.Data.Access;
using Sparker.Data.Models;
using Sparker.Process.Repositories;

namespace Sparker.Api.Controllers
{
    [RoutePrefix("api")]
    public class EventDetailsController : ApiController
    {
        private EventDetailRepository repo = new EventDetailRepository();

        [Route("EventDetails/Event/{eventId}")]
        [HttpGet]
        public IEnumerable<EventDetail> GetEventDetails(int eventId)
        {
            return repo.Get().Where(e => e.EventId.Equals(eventId));
        }

        // GET: api/EventDetails/5
        [ResponseType(typeof(EventDetail))]
        public IHttpActionResult GetEventDetail(int id)
        {
            EventDetail eventDetail = repo.Get(id);
            if (eventDetail == null)
            {
                return NotFound();
            }

            return Ok(eventDetail);
        }

        // PUT: api/EventDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEventDetail(int id, EventDetail eventDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventDetail.Id)
            {
                return BadRequest();
            }
            
            try
            {
                repo.Update(id, eventDetail);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EventDetails
        [ResponseType(typeof(EventDetail))]
        public IHttpActionResult PostEventDetail(EventDetail eventDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.Create(eventDetail);

            return CreatedAtRoute("DefaultApi", new { id = eventDetail.Id }, eventDetail);
        }

        // DELETE: api/EventDetails/5
        [ResponseType(typeof(EventDetail))]
        public IHttpActionResult DeleteEventDetail(int id)
        {
            EventDetail eventDetail = repo.Get(id);
            if (eventDetail == null)
            {
                return NotFound();
            }

            repo.Delete(id);

            return Ok(eventDetail);
        }

        private bool EventDetailExists(int id)
        {
            return repo.Get(id) != null;
        }
    }
}
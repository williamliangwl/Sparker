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
    public class EventsController : ApiController
    {
        private EventRepository repo = new EventRepository();

        [Route("Events/Region/{regionId}")]
        [HttpGet]
        public IEnumerable<Event> GetAllEvents(int regionId)
        {
            return repo.GetByRegion(regionId);
        }

        // GET: api/Events
        public IEnumerable<Event> GetAllEvents()
        {
            return repo.Get();
        }

        // GET: api/Events/5
        [ResponseType(typeof(Event))]
        public IHttpActionResult GetEvent(int id)
        {
            Event @event = repo.Get(id);
            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // PUT: api/Events/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEvent(int id, Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.Id)
            {
                return BadRequest();
            }
            
            try
            {
                repo.Update(id, @event);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/Events
        [ResponseType(typeof(Event))]
        public IHttpActionResult PostEvent(Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.Create(@event);

            return CreatedAtRoute("DefaultApi", new { id = @event.Id }, @event);
        }

        // DELETE: api/Events/5
        [ResponseType(typeof(Event))]
        public IHttpActionResult DeleteEvent(int id)
        {
            Event @event = repo.Get(id);
            if (@event == null)
            {
                return NotFound();
            }

            repo.Delete(id);

            return Ok(@event);
        }
        
        private bool EventExists(int id)
        {
            return repo.Get(id) != null;
        }
    }
}
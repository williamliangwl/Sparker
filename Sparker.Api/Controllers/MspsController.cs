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
using Sparker.Data.Models;
using Sparker.Process.Repositories;

namespace Sparker.Api.Controllers
{
    public class MspsController : ApiController
    {
        private MspRepository repo = new MspRepository();

        // GET: api/Msps
        public IEnumerable<Msp> GetMsps()
        {
            return repo.Get();
        }

        // GET: api/Msps/5
        [ResponseType(typeof(Msp))]
        public IHttpActionResult GetMsp(int id)
        {
            Msp msp = repo.Get(id);
            if (msp == null)
            {
                return NotFound();
            }

            return Ok(msp);
        }

        // PUT: api/Msps/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMsp(int id, Msp msp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }            

            try
            {
                repo.Update(id, msp);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MspExists(id))
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

        // POST: api/Msps
        [ResponseType(typeof(Msp))]
        public IHttpActionResult PostMsp(Msp msp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.Create(msp);

            return CreatedAtRoute("DefaultApi", new { id = msp.Id }, msp);
        }

        // DELETE: api/Msps/5
        [ResponseType(typeof(Msp))]
        public IHttpActionResult DeleteMsp(int id)
        {
            Msp msp = repo.Get(id);
            if (msp == null)
            {
                return NotFound();
            }

            repo.Delete(id);

            return Ok(msp);
        }
        
        private bool MspExists(int id)
        {
            return repo.Get(id) != null;
        }
    }
}
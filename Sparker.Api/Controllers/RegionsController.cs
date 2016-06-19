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
using Sparker.Api.Controllers;
using Sparker.Process.Repositories;

namespace Sparker.Api.Controllers
{
    public class RegionsController : ApiController
    {
        private RegionRepository repo = new RegionRepository();

        // GET: api/Regions
        public IEnumerable<Region> GetRegions()
        {
            return repo.Get();
        }

        // GET: api/Regions/5
        [ResponseType(typeof(Region))]
        public IHttpActionResult GetRegion(int id)
        {
            Region region = repo.Get(id);
            if (region == null)
            {
                return NotFound();
            }

            return Ok(region);
        }

        // PUT: api/Regions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRegion(int id, Region region)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != region.Id)
            {
                return BadRequest();
            }

            try
            {
                repo.Update(id, region);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionExists(id))
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

        // POST: api/Regions
        [ResponseType(typeof(Region))]
        public IHttpActionResult PostRegion(Region region)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.Create(region);

            return CreatedAtRoute("DefaultApi", new { id = region.Id }, region);
        }

        // DELETE: api/Regions/5
        [ResponseType(typeof(Region))]
        public IHttpActionResult DeleteRegion(int id)
        {
            Region region = repo.Get(id);
            if (region == null)
            {
                return NotFound();
            }

            repo.Delete(id);

            return Ok(region);
        }

        private bool RegionExists(int id)
        {
            return repo.Get(id) != null;
        }
    }
}
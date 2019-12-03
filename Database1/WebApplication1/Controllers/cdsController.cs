using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class cdsController : ApiController
    {
        private MarkRomigEntities1 db = new MarkRomigEntities1();

        // GET: api/cds
        public IQueryable<cd> Getcds()
        {
            return db.cds;
        }

        // GET: api/cds/5
        [ResponseType(typeof(cd))]
        public async Task<IHttpActionResult> Getcd(string id)
        {
            cd cd = await db.cds.FindAsync(id);
            if (cd == null)
            {
                return NotFound();
            }

            return Ok(cd);
        }

        // PUT: api/cds/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putcd(string id, cd cd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cd.cdID)
            {
                return BadRequest();
            }

            db.Entry(cd).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cdExists(id))
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

        // POST: api/cds
        [ResponseType(typeof(cd))]
        public async Task<IHttpActionResult> Postcd(cd cd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cds.Add(cd);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (cdExists(cd.cdID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cd.cdID }, cd);
        }

        // DELETE: api/cds/5
        [ResponseType(typeof(cd))]
        public async Task<IHttpActionResult> Deletecd(string id)
        {
            cd cd = await db.cds.FindAsync(id);
            if (cd == null)
            {
                return NotFound();
            }

            db.cds.Remove(cd);
            await db.SaveChangesAsync();

            return Ok(cd);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cdExists(string id)
        {
            return db.cds.Count(e => e.cdID == id) > 0;
        }
    }
}
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
    public class special_passionController : ApiController
    {
        private MarkRomigEntities1 db = new MarkRomigEntities1();

        // GET: api/special_passion
        public IQueryable<special_passion> Getspecial_passion()
        {
            return db.special_passion;
        }

        // GET: api/special_passion/5
        [ResponseType(typeof(special_passion))]
        public async Task<IHttpActionResult> Getspecial_passion(string id)
        {
            special_passion special_passion = await db.special_passion.FindAsync(id);
            if (special_passion == null)
            {
                return NotFound();
            }

            return Ok(special_passion);
        }

        // PUT: api/special_passion/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putspecial_passion(string id, special_passion special_passion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != special_passion.passionCode)
            {
                return BadRequest();
            }

            db.Entry(special_passion).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!special_passionExists(id))
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

        // POST: api/special_passion
        [ResponseType(typeof(special_passion))]
        public async Task<IHttpActionResult> Postspecial_passion(special_passion special_passion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.special_passion.Add(special_passion);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (special_passionExists(special_passion.passionCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = special_passion.passionCode }, special_passion);
        }

        // DELETE: api/special_passion/5
        [ResponseType(typeof(special_passion))]
        public async Task<IHttpActionResult> Deletespecial_passion(string id)
        {
            special_passion special_passion = await db.special_passion.FindAsync(id);
            if (special_passion == null)
            {
                return NotFound();
            }

            db.special_passion.Remove(special_passion);
            await db.SaveChangesAsync();

            return Ok(special_passion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool special_passionExists(string id)
        {
            return db.special_passion.Count(e => e.passionCode == id) > 0;
        }
    }
}
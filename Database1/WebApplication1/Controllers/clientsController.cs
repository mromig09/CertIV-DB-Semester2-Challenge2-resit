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
    public class clientsController : ApiController
    {
        private MarkRomigEntities1 db = new MarkRomigEntities1();

        // GET: api/clients
        public IQueryable<client> Getclients()
        {
            return db.clients;
        }

        // GET: api/clients/5
        [ResponseType(typeof(client))]
        public async Task<IHttpActionResult> Getclient(int id)
        {
            client client = await db.clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: api/clients/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putclient(int id, client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.clientNumber)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clientExists(id))
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

        // POST: api/clients
        [ResponseType(typeof(client))]
        public async Task<IHttpActionResult> Postclient(client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.clients.Add(client);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (clientExists(client.clientNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = client.clientNumber }, client);
        }

        // DELETE: api/clients/5
        [ResponseType(typeof(client))]
        public async Task<IHttpActionResult> Deleteclient(int id)
        {
            client client = await db.clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            db.clients.Remove(client);
            await db.SaveChangesAsync();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool clientExists(int id)
        {
            return db.clients.Count(e => e.clientNumber == id) > 0;
        }
    }
}
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
    public class salesController : ApiController
    {
        private MarkRomigEntities1 db = new MarkRomigEntities1();

        // GET: api/sales
        public IQueryable<sale> Getsales()
        {
            return db.sales;
        }

        // GET: api/sales/5
        [ResponseType(typeof(sale))]
        public async Task<IHttpActionResult> Getsale(DateTime id)
        {
            sale sale = await db.sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            return Ok(sale);
        }

        // PUT: api/sales/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putsale(DateTime id, sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sale.dateOrdered)
            {
                return BadRequest();
            }

            db.Entry(sale).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!saleExists(id))
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

        // POST: api/sales
        [ResponseType(typeof(sale))]
        public async Task<IHttpActionResult> Postsale(sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.sales.Add(sale);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (saleExists(sale.dateOrdered))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sale.dateOrdered }, sale);
        }

        // DELETE: api/sales/5
        [ResponseType(typeof(sale))]
        public async Task<IHttpActionResult> Deletesale(DateTime id)
        {
            sale sale = await db.sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            db.sales.Remove(sale);
            await db.SaveChangesAsync();

            return Ok(sale);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool saleExists(DateTime id)
        {
            return db.sales.Count(e => e.dateOrdered == id) > 0;
        }
    }
}
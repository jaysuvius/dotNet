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
using MayPsApit.Models;

namespace MayPsApit.Controllers
{
    public class RepairsController : ApiController
    {
        private MayPsDbEntities db = new MayPsDbEntities();

        // GET: api/Repairs
        public IQueryable<Repair> GetRepairs()
        {
            return db.Repairs;
        }

        // GET: api/Repairs/5
        [ResponseType(typeof(Repair))]
        public async Task<IHttpActionResult> GetRepair(Guid id)
        {
            Repair repair = await db.Repairs.FindAsync(id);
            if (repair == null)
            {
                return NotFound();
            }

            return Ok(repair);
        }

        // PUT: api/Repairs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRepair(Guid id, Repair repair)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != repair.RepairId)
            {
                return BadRequest();
            }

            db.Entry(repair).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairExists(id))
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

        // POST: api/Repairs
        [ResponseType(typeof(Repair))]
        public async Task<IHttpActionResult> PostRepair(Repair repair)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Repairs.Add(repair);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RepairExists(repair.RepairId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = repair.RepairId }, repair);
        }

        // DELETE: api/Repairs/5
        [ResponseType(typeof(Repair))]
        public async Task<IHttpActionResult> DeleteRepair(Guid id)
        {
            Repair repair = await db.Repairs.FindAsync(id);
            if (repair == null)
            {
                return NotFound();
            }

            db.Repairs.Remove(repair);
            await db.SaveChangesAsync();

            return Ok(repair);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RepairExists(Guid id)
        {
            return db.Repairs.Count(e => e.RepairId == id) > 0;
        }
    }
}
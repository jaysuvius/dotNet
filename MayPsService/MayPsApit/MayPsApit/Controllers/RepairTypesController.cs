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
    public class RepairTypesController : ApiController
    {
        private MayPsDbEntities db = new MayPsDbEntities();

        // GET: api/RepairTypes
        public IQueryable<RepairType> GetRepairTypes()
        {
            return db.RepairTypes;
        }

        // GET: api/RepairTypes/5
        [ResponseType(typeof(RepairType))]
        public async Task<IHttpActionResult> GetRepairType(Guid id)
        {
            RepairType repairType = await db.RepairTypes.FindAsync(id);
            if (repairType == null)
            {
                return NotFound();
            }

            return Ok(repairType);
        }

        // PUT: api/RepairTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRepairType(Guid id, RepairType repairType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != repairType.RepairTypeId)
            {
                return BadRequest();
            }

            db.Entry(repairType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairTypeExists(id))
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

        // POST: api/RepairTypes
        [ResponseType(typeof(RepairType))]
        public async Task<IHttpActionResult> PostRepairType(RepairType repairType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RepairTypes.Add(repairType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RepairTypeExists(repairType.RepairTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = repairType.RepairTypeId }, repairType);
        }

        // DELETE: api/RepairTypes/5
        [ResponseType(typeof(RepairType))]
        public async Task<IHttpActionResult> DeleteRepairType(Guid id)
        {
            RepairType repairType = await db.RepairTypes.FindAsync(id);
            if (repairType == null)
            {
                return NotFound();
            }

            db.RepairTypes.Remove(repairType);
            await db.SaveChangesAsync();

            return Ok(repairType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RepairTypeExists(Guid id)
        {
            return db.RepairTypes.Count(e => e.RepairTypeId == id) > 0;
        }
    }
}
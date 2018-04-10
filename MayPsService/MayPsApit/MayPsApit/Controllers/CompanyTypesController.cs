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
    public class CompanyTypesController : ApiController
    {
        private MayPsDbEntities db = new MayPsDbEntities();

        // GET: api/CompanyTypes
        public IQueryable<CompanyType> GetCompanyTypes()
        {
            return db.CompanyTypes;
        }

        // GET: api/CompanyTypes/5
        [ResponseType(typeof(CompanyType))]
        public async Task<IHttpActionResult> GetCompanyType(Guid id)
        {
            CompanyType companyType = await db.CompanyTypes.FindAsync(id);
            if (companyType == null)
            {
                return NotFound();
            }

            return Ok(companyType);
        }

        // PUT: api/CompanyTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCompanyType(Guid id, CompanyType companyType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companyType.CompanyTypeId)
            {
                return BadRequest();
            }

            db.Entry(companyType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyTypeExists(id))
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

        // POST: api/CompanyTypes
        [ResponseType(typeof(CompanyType))]
        public async Task<IHttpActionResult> PostCompanyType(CompanyType companyType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CompanyTypes.Add(companyType);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CompanyTypeExists(companyType.CompanyTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = companyType.CompanyTypeId }, companyType);
        }

        // DELETE: api/CompanyTypes/5
        [ResponseType(typeof(CompanyType))]
        public async Task<IHttpActionResult> DeleteCompanyType(Guid id)
        {
            CompanyType companyType = await db.CompanyTypes.FindAsync(id);
            if (companyType == null)
            {
                return NotFound();
            }

            db.CompanyTypes.Remove(companyType);
            await db.SaveChangesAsync();

            return Ok(companyType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyTypeExists(Guid id)
        {
            return db.CompanyTypes.Count(e => e.CompanyTypeId == id) > 0;
        }
    }
}
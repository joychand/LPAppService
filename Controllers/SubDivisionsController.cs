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
using eSiroi.Resource.Entities;

namespace eSiroi.Resource.Controllers
{
    public class SubDivisionsController : ApiController
    {
        private eSiroiReSrcDbContext db = new eSiroiReSrcDbContext();

        // GET: api/SubDivisions
        public IQueryable<SubDivision> GetSubDivision()
        {
            return db.SubDivision;
        }

        // GET: api/SubDivisions/5
        [ResponseType(typeof(SubDivision))]
        public async Task<IHttpActionResult> GetSubDivision(string id)
        {
            SubDivision subDivision = await db.SubDivision.FindAsync(id);
            if (subDivision == null)
            {
                return NotFound();
            }

            return Ok(subDivision);
        }

        // PUT: api/SubDivisions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubDivision(string id, SubDivision subDivision)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subDivision.DistCode)
            {
                return BadRequest();
            }

            db.Entry(subDivision).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubDivisionExists(id))
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

        // POST: api/SubDivisions
        [ResponseType(typeof(SubDivision))]
        public async Task<IHttpActionResult> PostSubDivision(SubDivision subDivision)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubDivision.Add(subDivision);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SubDivisionExists(subDivision.DistCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = subDivision.DistCode }, subDivision);
        }

        // DELETE: api/SubDivisions/5
        [ResponseType(typeof(SubDivision))]
        public async Task<IHttpActionResult> DeleteSubDivision(string id)
        {
            SubDivision subDivision = await db.SubDivision.FindAsync(id);
            if (subDivision == null)
            {
                return NotFound();
            }

            db.SubDivision.Remove(subDivision);
            await db.SaveChangesAsync();

            return Ok(subDivision);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubDivisionExists(string id)
        {
            return db.SubDivision.Count(e => e.DistCode == id) > 0;
        }
    }
}
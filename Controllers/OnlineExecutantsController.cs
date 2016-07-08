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
//using eSiroi.Resource.Repository;

namespace eSiroi.Resource.Controllers
{
    public class OnlineExecutantsController : ApiController
    {
        private eSiroiReSrcDbContext db = new eSiroiReSrcDbContext();

        // GET: api/OnlineExecutants
        public IQueryable<OnlineExecutant> GetOnlineExecutant()
        {
            return db.OnlineExecutant;
        }

        // GET: api/OnlineExecutants/5
       // [ResponseType(typeof(OnlineExecutant))]
        //public  List<OnlineExecutant> GetOnlineExecutant(int id)
        //{

        //    //IQueryable<OnlineExecutant> query;
        //    //return query = from OnlineExecutant in db.OnlineExecutant.Where(v => v.Ackno == id)
        //    //                   select OnlineExecutant
        //    //                   .ToList();

        //    OnlineExecutant onlineExecutant = await db.OnlineExecutant.FindAsync(id);
        //    if (onlineExecutant == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(onlineExecutant);
        //}

        // PUT: api/OnlineExecutants/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutOnlineExecutant(int id, OnlineExecutant onlineExecutant)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != onlineExecutant.Ackno)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(onlineExecutant).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OnlineExecutantExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/OnlineExecutants
        [ResponseType(typeof(OnlineExecutant))]
        public async Task<IHttpActionResult> PostOnlineExecutant([FromBody]OnlineExecutant executants)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //if executants.count > 0
            //
           db.OnlineExecutant.Add(executants);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OnlineExecutantExists(executants.Ackno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = executants.Ackno }, executants);
        }

        // DELETE: api/OnlineExecutants/5
        [ResponseType(typeof(OnlineExecutant))]
        public async Task<IHttpActionResult> DeleteOnlineExecutant(int id)
        {
            OnlineExecutant onlineExecutant = await db.OnlineExecutant.FindAsync(id);
            if (onlineExecutant == null)
            {
                return NotFound();
            }

            db.OnlineExecutant.Remove(onlineExecutant);
            await db.SaveChangesAsync();

            return Ok(onlineExecutant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OnlineExecutantExists(String id)
        {
            return db.OnlineExecutant.Count(e => e.Ackno == id) > 0;
        }
        //[HttpGet]
        //public HttpResponseMessage States()
        //{
        //    var states = _Repository.GetStates();
        //    return Request.CreateResponse(HttpStatusCode.OK, states);
        //}
    }
}
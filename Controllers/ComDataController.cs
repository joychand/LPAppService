using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using eSiroi.Resource.Entities;

using System.Web.Http.Description;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace eSiroi.Resource.Controllers
{
     [RoutePrefix("api/ComDataController")]
    public class ComDataController : ApiController
    {
        private eSiroiReSrcDbContext db = new eSiroiReSrcDbContext();
        //get PoliceStation
        [HttpGet]
        [Route("getPoliceStations")]

        public IHttpActionResult getPoliceStations()
        {
            var po = db.PoliceStation;
            if (po.Any())
            {
                return Ok(po);

            }
            return NotFound();
        }

         //GET OCCUPATIONS
         [HttpGet]
         [Route("getOccupations")]
        public IHttpActionResult getOccupations()
        {
            var Ocuptn = db.Occupation;
                         
            if (Ocuptn.Any())
            {
                return Ok(Ocuptn);
            }
            else return NotFound();
        }
    }
}

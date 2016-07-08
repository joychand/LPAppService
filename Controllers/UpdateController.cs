using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using eSiroi.Resource.Entities;
//using eSiroi.Resource.Entities;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Collections;
using eSiroi.Resource.Models;
using eSiroi.Resource.ErrorResponse;
namespace eSiroi.Resource.Controllers
{
    [RoutePrefix("api/OnlineUpdate")]
    public class UpdateController : ApiController
    {
        private eSiroiReSrcDbContext dbase = new eSiroiReSrcDbContext();
        [HttpPost]
        [Route("getExecutantlist")]
        public IHttpActionResult getExecutant([FromBody]ApplicationStatus Oappln)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var list= dbase.Executant
                     .Where(e=>(e.TSNo==Oappln.tsno && e.TSYear==Oappln.tsyear));
            if (list.Any())
            {
                return Ok(list);
            }
             return NotFound();  

        }

        [HttpPost]
        [Route("getClaimantlist")]
        public IHttpActionResult getClaimant([FromBody]ApplicationStatus Oappln)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var list = dbase.Claimant
                     .Where(c => (c.TSNo == Oappln.tsno && c.TSYear == Oappln.tsyear));
            if (list.Any())
            {
                return Ok(list);
            }
            return NotFound();

        }

        [HttpPost]
        [Route("getIdentifierlist")]
        public IHttpActionResult getIdentifier([FromBody]ApplicationStatus Oappln)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var list = dbase.Identifier
                     .Where(i => (i.TSNo == Oappln.tsno && i.TSYear == Oappln.tsyear));
            if (list.Any())
            {
                return Ok(list);
            }
            return NotFound();

        }

        [HttpPost]
        [Route("getProperty")]
        public IHttpActionResult getProperty([FromBody]ApplicationStatus Oappln)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var list = dbase.Plot
                     .Where(p => (p.TSNo == Oappln.tsno && p.TSYear == Oappln.tsyear));
            if (list.Any())
            {
                return Ok(list);
            }
            return NotFound();

        }

        [HttpPost]
        [Route("DeedEntered")]
        public async Task<IHttpActionResult> uDeedEntered([FromBody] ApplicationStatus ApplnModel)
        {
            var appln = dbase.Application
                   .Where(a => a.TSNo == ApplnModel.tsno && a.TSYear == ApplnModel.tsyear && a.sro == ApplnModel.sro).FirstOrDefault();
            appln.status = ApplnModel.status;
            //var reason = "plot";
            if (ApplnModel.remarks.Length > 0)
            //if(reason.Length>0)
            {
                appln.remarks = ApplnModel.remarks;
            }

            if (ApplnModel.Ackno!=null)
            {
                onlineapplication onlineApplication = dbase.onlineapplication
                                    .Where(o => (SqlFunctions.StringConvert((double)o.ackno)+""+o.sro+""+o.year) == ApplnModel.Ackno).SingleOrDefault();
                onlineApplication.status = ApplnModel.status;
                if (ApplnModel.remarks.Length > 0)
                {
                    onlineApplication.remarks = ApplnModel.remarks;
                }
            }

            try
            {
                await dbase.SaveChangesAsync();
            }

            catch (DbUpdateException e)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        [Route("uploadComplete")]
        public async Task<IHttpActionResult> uDeedEntered([FromBody] ApplicationUploadModel ApplnModel)
        {
            var appln = dbase.Application
                   .Where(a => a.TSNo == ApplnModel.tsno && a.TSYear == ApplnModel.tsyear && a.sro == ApplnModel.sro).FirstOrDefault();
            appln.filePath = ApplnModel.filePath;
            try
            {
                await dbase.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                 return new HttpActionResult(HttpStatusCode.InternalServerError, "could not update filepath");
            }
            return Ok();
        }
    }
}

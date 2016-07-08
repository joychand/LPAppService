using eSiroi.Resource.Entities;
using eSiroi.Resource.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace eSiroi.Resource.Controllers
{
    [RoutePrefix("api/SRController")]
    public class SRController : ApiController
    {
        private eSiroiReSrcDbContext db = new eSiroiReSrcDbContext();
        [HttpPost]
        [Route("getPdf")]
        public HttpResponseMessage GetPdf([FromBody]ApplicationStatus appln)
        {
            HttpResponseMessage result = null;
            var serverpath=HttpContext.Current.Server.MapPath("~/uploadFile");
           // MemoryStream pdf = serverpath + "2802263e-bf1b-48a4-9b91-4ecedfa9391b.PDF"; //get the memorysteram of the pdf here
            var filepath = db.Application
                         .Where(a => a.TSNo == appln.tsno && a.TSYear == appln.tsyear)
                         .Select(a => a.filePath).SingleOrDefault();
            var fullpath = serverpath + "" + "/" + filepath;
            MemoryStream pdf = new MemoryStream(System.IO.File.ReadAllBytes(fullpath));
           // HttpResponseMessage result = null;
            result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(pdf.ToArray());
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = filepath.Trim();
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            //return File(@"C:\MyFile.pdf", "application/pdf");
            //return File(new FileStream(@file, FileMode.Open, FileAccess.Read), "application/pdf");
            return result;
        }

        [HttpPost]
        [Route("finalizeApplication")]
        public async Task<IHttpActionResult> finalize(ApplicationStatus application)
        {

            Application appln = db.Application
                   .Where(a => a.TSNo == application.tsno && a.TSYear == application.tsyear && a.sro == application.sro).FirstOrDefault();
            appln.status = application.status;
           

            if (application.Ackno != null)
            {
                onlineapplication oAppln = db.onlineapplication
                                    .Where(o => SqlFunctions.StringConvert((double)o.ackno).Trim() + "" + o.sro + "" + o.year == application.Ackno).SingleOrDefault();
                oAppln.status = application.status;
               
            }

            try
            {
                await db.SaveChangesAsync();
            }

            catch (DbUpdateException e)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet]
        [Route("gettrialPdf")]
        public HttpResponseMessage GetPdf()
        {
            HttpResponseMessage result = null;
            var serverpath = HttpContext.Current.Server.MapPath("~/uploadFile");
            // MemoryStream pdf = serverpath + "2802263e-bf1b-48a4-9b91-4ecedfa9391b.PDF"; //get the memorysteram of the pdf here
            var filepath = db.Application
                         .Where(a => a.TSNo ==2 && a.TSYear == 2016)
                         .Select(a => a.filePath).SingleOrDefault();
            var fullpath = serverpath + "" + "/" + filepath;
            MemoryStream pdf = new MemoryStream(System.IO.File.ReadAllBytes(fullpath));
            // HttpResponseMessage result = null;
            result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(pdf.ToArray());
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = filepath.Trim();
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            //return File(@"C:\MyFile.pdf", "application/pdf");
            //return File(new FileStream(@file, FileMode.Open, FileAccess.Read), "application/pdf");
            return result;
        }
    }
}

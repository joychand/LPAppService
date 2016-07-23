using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using LPAppService.Entities;

using System.Web.Http.Description;
using System.Threading.Tasks;
using System.Web.Http.Results;
using eSiroi.Resource.Models;
using System.Data;
using System.Web;

using System.IO;
using System.Net.Http.Headers;
using System.Collections.Specialized;

using LPAppService.Filters;

namespace LPAppService.Controllers
{
 [lpHMACAuthenticationAttribute]
    [RoutePrefix("api/LPAppController")]
    public class LPAppController : ApiController
    {
        private LpDbContext db = new LpDbContext();
        #region PattaQuery
        //get district
        [HttpGet]
        [Route("getDistrict")]
        public IEnumerable<UniDistrict> getdistrict()
        {
            return db.UniDistrict;
        }
        [HttpGet]
        [Route("{dcode:regex(^[0-9]{2,2}$)}/getCircle")]
        public IHttpActionResult getcircle(string dcode)
        {
            //IEnumerable<UniCircle> clist;
            var query = from c in db.UniCircle
                    where c.distcode == dcode
                    select new 
                    {
                       distcode= c.distcode,
                        circode=c.circode,
                       subcode=c.subcode,
                       cirDesc=c.cirDesc

                    };
            if (query.Any())
            {
                return Ok(query);

            }
            return NotFound();
        }
        //getVillage
        [HttpPost]
        [Route("postVillage")]
        [ValidateModel]
        public IHttpActionResult postVillage(UniCircle circ)
        {
           
           var vlist = db.UniLocation
                .Where(l => l.LocCd.Substring(0, 7).Equals(circ.distcode + circ.subcode + circ.circode));
           if (vlist.Any())
           {
               return Ok(vlist);
           }
           return NotFound();
        }
        [HttpPost]
        [Route("getOwnDetail")]
        [ValidateModel]
        public IHttpActionResult getOwnDetail(PqModel pq)
        {
            var query = db.Uniowners
                      .Where(o => (o.LocCd.Equals(pq.LocCd) && o.NewDagNo == pq.NewDagNo && o.NewPattaNo == pq.NewPattaNo))
                      .Select(o => new
                      {
                          ownno=o.ownno,
                          Name = o.Name,
                          Father = o.Father,
                          Address = o.Address

                      }).OrderBy(o=>o.ownno);
            if(query.Any()){
                return Ok(query);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("getplotDetail")]
        [ValidateModel]
        public IHttpActionResult getplotDetail(PqModel pq)
        {
            var query = db.Uniplots
                      .Where(o => (o.LocCd.Equals(pq.LocCd) && o.NewDagNo == pq.NewDagNo && o.NewPattaNo == pq.NewPattaNo))
                      .Select(o => new { o.LocCd, o.NewDagNo, o.OldDagNo, o.NewPattaNo, o.Area, o.Area_acre, o.LandClass })
                      .FirstOrDefault();
            if (query!=null)
            {
                return Ok(query);
            }
            return NotFound();
        }
    

        [HttpPost]
        [Route("Jamabandi")]
        [ValidateModel]
        public HttpResponseMessage Jamabandi(PqModel pq)
        {
            HttpResponseMessage result = null;
            string remoteUri = "http://10.178.0.4/lpapps/jamabandipdf.php";
            WebClient myWebClient = new WebClient();
            //myWebClient.UseDefaultCredentials = true;

            NameValueCollection myQueryStringCollection = new NameValueCollection();
            myQueryStringCollection.Add("l", pq.LocCd);
            myQueryStringCollection.Add("p", pq.NewPattaNo);
            myQueryStringCollection.Add("dg", pq.NewDagNo);
            myWebClient.QueryString = myQueryStringCollection;
            byte[] pdf = myWebClient.DownloadData(remoteUri);
            //MemoryStream pdf = new MemoryStream(System.IO.File.ReadAllBytes(fullpath));
            // HttpResponseMessage result = null;
            result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new ByteArrayContent(pdf);
            //result.Content = pdf;
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = DateTime.Now.ToShortDateString();
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            //return File(@"C:\MyFile.pdf", "application/pdf");
            //return File(new FileStream(@file, FileMode.Open, FileAccess.Read), "application/pdf");
            return result;
        }
    }

#endregion

   
}

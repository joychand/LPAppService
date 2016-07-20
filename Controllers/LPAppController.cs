using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using LPAppService.Entities;
//using eSiroi.Resource.Migrations.Entities;
//using eSiroi.Resource.Repository;
using System.Web.Http.Description;
using System.Threading.Tasks;
using System.Web.Http.Results;
using eSiroi.Resource.Models;
using System.Data;
using System.Web;
//using iTextSharp.text.pdf;
//using iTextSharp.text;


using System.IO;
using System.Net.Http.Headers;
//using System.Text;
//using Aspose.Pdf.Generator;
using System.Collections.Specialized;
using LPAppServiceHMACAuthentication.Filters;

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
        [Route("{dcode}/getCircle")]
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
        public IHttpActionResult postVillage(UniCircle circ)
        {
            //VAR DISTCODE="07";
            //VAR SUBCODE="01";
            //VAR CIRCODE = "002";
            //002
            //IEnumerable<UniLocation> vlist;
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
        //[HttpPost]
        //[Route("getmasterlandvalue")]
        //public IHttpActionResult getmasterlandvalue([FromBody]string unit )
        //{
        //    var query = db.MasterLandValue
        //              .Where(l => l.Unit.Contains(unit.ToString()))
        //              .Select(l => new { l.Unit, l.Details, l.Rate1, l.Rate2, l.Rate3, l.Remark1, l.Remark2, l.Remark3 });
                     
        //    if (query.Any())
        //    {
        //        return Ok(query);
        //    }
        //    return NotFound();
        //}

        //[HttpPost]
        //[Route("getunitgroup")]
        //public IHttpActionResult getunitgroup()
        //{
        //    var query = db.MasterLandValue

        //              .Select(l => new { l.Unit});

        //    if (query != null)
        //    {
        //        return Ok(query);
        //    }
        //    return NotFound();
        //}

        //[HttpGet]
        //[Route("getJammabandi")]
        //public HttpResponseMessage getJammabandi()
        //{

        //    //Aspose pdf test//

        //    // create MemoryStream object
        //    HttpResponseMessage result = null;
        //    MemoryStream ms = new MemoryStream();
        //    // create PDf object
        //    Pdf pdf = new Pdf(ms);
        //    // create PDf section
        //    Aspose.Pdf.Generator.Section sec1 = pdf.Sections.Add();
        //    // add sample Text paragraph to section
        //    sec1.Paragraphs.Add(new Text("নম্বোল..."));
        //    // save the output in MemoryStream object
        //    pdf.Close();
        //    result = Request.CreateResponse(HttpStatusCode.OK);
        //    result.Content = new ByteArrayContent(ms.ToArray());
        //    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
        //    result.Content.Headers.ContentDisposition.FileName = new DateTime().ToString() + ".pdf";
        //    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
        //    return result;
        //    // close MemoryStream
        //   // ms.Close();
        ////    var path = System.Web.HttpContext.Current.Server.MapPath("~/fonts/test.docx"); ;
        ////    HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
        ////    var stream = new FileStream(path, FileMode.Open);
        ////   // result.Content = new StreamContent(stream);
        ////    result.Content = new ByteArrayContent(stream.GetBuffer());
        ////    result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
        ////    result.Content.Headers.ContentDisposition.FileName = Path.GetFileName(path);
        ////    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        ////    result.Content.Headers.ContentLength = stream.Length;
        ////    return result; 


        ////MemoryStream pdfmemorystream = new MemoryStream();
        ////HttpResponseMessage result = null;
        //////    //StringBuilder sbHtmlText = new StringBuilder();
        //////    //sbHtmlText.Append("<html><head>Employee Info নম্বোল</head>");
        //////    //sbHtmlText.Append("<body>Hi This is Employee Info</body></html>");

        ////string fontpath = HttpContext.Current.Server.MapPath("~/fonts/");
        ////BaseFont customfont = BaseFont.CreateFont(fontpath + "vrinda.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        ////FontFactory.Register(fontpath,BaseFont.IDENTITY_H);
        ////Document doc = new Document();
        //////    //PdfWriter.GetInstance(doc, pdfmemorystream);
        ////RtfWriter2 rtfWriter = RtfWriter2.GetInstance(doc, pdfmemorystream);
        ////    //Font font = new Font(customfont, 12);
        ////    //string s = "নম্বোল";
        ////    //doc.Open();
        ////    ////Font rock_11_bold_header = new Font(customfont, 11, Font.NORMAL, new BaseColor(190, 36, 34));
        ////    ////PdfPCell descHeadrCell = new PdfPCell();
        ////    ////descHeadrCell.AddElement(new Phrase("Demo"), rock_11_bold_header));
        ////    //iTextSharp.text.html.simpleparser.HTMLWorker hw = new iTextSharp.text.html.simpleparser.HTMLWorker(doc);
        ////    //hw.Parse(new StringReader(sbHtmlText.ToString()));
        ////    //doc.Add(new Paragraph(s, font));
        ////    //doc.Close();
        ////    //result = Request.CreateResponse(HttpStatusCode.OK);
        ////    //result.Content = new ByteArrayContent(pdfmemorystream.ToArray());
        ////    //result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
        ////    //result.Content.Headers.ContentDisposition.FileName = new DateTime().ToString() + ".pdf";
        ////    //result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
        ////    //return result;
        //}

        [HttpPost]
        [Route("Jamabandi")]
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

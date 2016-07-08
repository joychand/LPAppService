using eSiroi.Resource.Entities;
using eSiroi.Resource.ErrorResponse;
using eSiroi.Resource.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
    public class UploadController : ApiController
    {
        //private static readonly string ServerUploadFolder = "E:\\uploadFile"; //Path.GetTempPath();
        private eSiroiReSrcDbContext dbase = new eSiroiReSrcDbContext();
        [HttpPost]
        [Route("api/UploadController/upload")]
        public async Task<IHttpActionResult> upload()
        {
            if (Request.Content.IsMimeMultipartContent())
            {
                try
                {
                    var filename="";
                    string uploadPath = HttpContext.Current.Server.MapPath("~/uploadFile");
                    //string uploadPath = ServerUploadFolder;
                    MyStreamProvider streamProvider = new MyStreamProvider(uploadPath);

                    await Request.Content.ReadAsMultipartAsync(streamProvider);

                    //List<string> messages = new List<string>();
                    foreach (var file in streamProvider.FileData)
                    {
                        FileInfo fi = new FileInfo(file.LocalFileName);
                        filename = fi.Name;
                        //var appln = dbase.Application
                        //           .Where(a => a.TSNo == ApplnModel.tsno && a.TSYear == ApplnModel.tsyear && a.sro == ApplnModel.sro).FirstOrDefault();
                       // messages.Add("File uploaded as " + fi.FullName + " (" + fi.Length + " bytes)");
                        //appln.filePath = fi.FullName;
                    }

                   

                    return Ok(filename);
                }

                catch(Exception e)
                {
                     return new HttpActionResult(HttpStatusCode.InternalServerError, "upload fail"); 
                }
               
            }
            else
            {
                return BadRequest();
            }
        }
    }

    // helper class MyStreamProvider

    public class MyStreamProvider : MultipartFormDataStreamProvider
    {
        public MyStreamProvider(string uploadPath)
            : base(uploadPath)
        {

        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            string fileName = (headers.ContentDisposition.FileName).Replace("\"", string.Empty);

            string newfileName = Guid.NewGuid() + Path.GetExtension(fileName);
            //if (string.IsNullOrWhiteSpace(fileName))
            //{
            //    fileName = Guid.NewGuid().ToString() + ".data";
            //}
            //return newfileName.Replace("\"", string.Empty);
            return newfileName;
        }
    }
}

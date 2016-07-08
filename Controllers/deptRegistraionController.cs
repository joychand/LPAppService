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


namespace eSiroi.Resource.Controllers
{
    [RoutePrefix("api/deptRegistraionController")]
    public class deptRegistraionController : ApiController
    {
        private eSiroiReSrcDbContext db = new eSiroiReSrcDbContext();
        private LpDbContext lpdb = new LpDbContext();

        #region GET ONLINE APPLICATION
        [HttpGet]
        [Route("{status}/getAppln")]
        public IHttpActionResult getAppln(String status)
        {

            var query = from oAppln in db.onlineapplication
                        join ro in db.RegistarOffice
                        on oAppln.sro equals SqlFunctions.StringConvert((double)ro.RegOfficeCode).Trim()

                        join trans in db.MajorTrans_code
                        on oAppln.trans_maj_code equals trans.tran_maj_code
                        where oAppln.status == status
                        select new
                        {
                            ackno = oAppln.ackno,

                            sro = ro.RegOfficeName,
                            roCode = ro.RegOfficeCode,
                            transaction = trans.tran_name,
                            trans_code = trans.tran_maj_code,
                            date = oAppln.date,
                            year=oAppln.year



                        };
            if (query.Any())
            {
                return Ok(query);
            }
            return NotFound();
        }

        #endregion

        #region COMMON DATA SERVICE API
        // get Exempt reason
        [HttpGet]
        [Route("ExemptReason")]
        public IHttpActionResult getReason()
        {
            var reason= db.Exempt_Reason;
            if(reason.Any())
            {
                return Ok(reason);
            }
            return NotFound();
        }

        ////Get LandType 
        [HttpGet]
        [Route("landtype")]
        public IHttpActionResult getlandtype()
        {


            var landtype = db.LandType;

            if (landtype.Any())
            {
                return Ok(landtype);
            }

            return NotFound();

        }
        // Get LandClass
        [HttpGet]
        [Route("landclass")]
        public IHttpActionResult getlandclass()
        {
            var landclass = db.Class;
            if (landclass.Any())
            {
                return Ok(landclass);

            }
            return NotFound();
        }
        #endregion

        //# region DeedForm API

        //POST DEED DETAILS
        [HttpPost]
        [Route("postdeed")]
        public async Task<IHttpActionResult> postdeed([FromBody] Deed deedDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //DateTime entrydate=DateTime.UtcNow;
            deedDetails.EntryDt = DateTime.UtcNow;
            db.Deed.Add(deedDetails);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {

                throw;


            }
            return Ok();
        }

        //// GET DEEDS STATUS
        ////[Authorize]

        [Route("{status}/getApplication")]
        public IHttpActionResult getApplication(String status)
        {
            var query = from apln in db.Application
                        join ro in db.RegistarOffice
                        on apln.sro equals ro.RegOfficeCode.ToString()
                        join trans in db.MajorTrans_code
                        on apln.trans_maj_code equals trans.tran_maj_code
                        where apln.status == status
                        select new
                        {
                            TS = apln.TSNo,
                            TYear = apln.TSYear,
                            sro = ro.RegOfficeName,
                            ackno = apln.ackno,
                            roCode = ro.RegOfficeCode,
                            transaction = trans.tran_name,
                            trans_code = trans.tran_maj_code,
                            status = apln.status,
                            //enterby = d.EnterBy,
                            date = apln.Entrydate,
                            remarks = apln.remarks,



                        };
            if (query.Any())
            {
                return Ok(query);
            }
            return NotFound();
        }

        // [Authorize]
        [Route("{ts}/{tsyear}/deedinfo")]
        public IHttpActionResult getdeedinfo(int ts, int tsyear)
        {
            var deedinfo = db.Deed
                          .Where(d => d.TSNo == ts && d.TSYear == tsyear)
                          .Select(list => new
                          {
                              list.RegNo,
                              list.RegYear,
                              list.RegDate,
                              list.TransType,
                              list.EntryDt,
                              list.EnterBy,
                              list.Date_Exec,
                              list.Date_Time_Present


                          });
            if (deedinfo.Any())
            {
                return Ok(deedinfo);
            }
            return NotFound();

        }
       // # endregion DeedFrom API


        # region PropertyFrom API
        //Get Property Details
        [HttpGet]
        [Route("{ackno}/property")]
        public IHttpActionResult getOnlineProperty(string ackno)
        {
            var plotdetail = db.onlinePlot
                           .Where(p => p.ackno == ackno)
                           .Select(list => new { list.ackno, list.DagNo, list.PattaNo, list.TransactedArea, list.LandType, list.Class });
            if (plotdetail.Any())
            {
                return Ok(plotdetail);
            }
            else
                return NotFound();
        }

        // Get property ddl list
        [Route("{ackno}/propertyddl")]
        public IHttpActionResult getOnlinePropertyddl(string ackno)
        {
            var plotddl = db.onlinePlot
                           .Where(p => p.ackno == ackno)
                           .Select(list => new { list.ackno, list.State, list.District, list.Subdivision, list.Circle, list.Village });
            if (plotddl.Any())
            {
                return Ok(plotddl);
            }
            else
                return NotFound();
        }

        //INSERT PORPERTY DETAILS
        [Route("postPlotDetail")]
        public async Task<IHttpActionResult> postProperty(Plot plot)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Plot.Add(plot);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                return InternalServerError(e);
            }
            return Ok();

        }

        ////GET PROPERTY DETIALS
        //// [Authorize]
        [Route("{ts}/{tyear}/propertyinfo")]
        public IHttpActionResult getPropertyinfo(int ts, int tyear)
        {
            var plotinfo = db.Plot
                         .Where(p => p.TSNo == ts && p.TSYear == tyear)
                         .Select(list => new
                         {
                             list.DagNo,
                             list.PattaNo,
                             list.TransactedArea,
                             list.Unit,
                             list.LandType,
                             list.Village,
                             list.Circle,
                             list.District

                         });
            if (plotinfo.Any())
            {
                return Ok(plotinfo);
            }
            return NotFound();
        }
        #endregion

        #region PartyDetails API
        //GET EXECUTANT LIST
        [HttpGet]
        [Route("{ackno}/excutantlist")]
        public IHttpActionResult excutantlist(string ackno)
        {

            //return db.OnlineExecutant 
            // IEnumerable<OnlineExecutant> elist;
            var elist = db.OnlineExecutant
                        .Where(b => b.Ackno == ackno)
                        .Select(list => new
                        {
                            list.SlNo,
                            list.ExecSurName,
                            list.ExecMiddleName,
                            list.ExecLastName,
                            list.Mobile,
                            list.Aadhaar,
                            list.FatherSurName,
                            list.FatherMiddleName,
                            list.FatherLastName,
                            list.Sex,
                            list.Occupation,
                            list.Alias
                        });


            if (elist.Any())
            {
                return Ok(elist);
            }
            else
                return NotFound();


        }
        // GET EXECUTANT INFO
        [HttpGet]
        [Route("{ts}/{tyear}/executantInfo")]
        public IHttpActionResult getexecutantInfo(int ts, int tyear)
        {
            var execInfo = db.Executant
                         .Where(e => e.TSNo == ts && e.TSYear == tyear)
                         .Select(list => new
                         {
                             list.ExecSurName,
                             list.ExecMiddleName,
                             list.ExecLastName,
                             list.FatherSurName,
                             list.FatherMiddleName,
                             list.FatherLastName,
                             list.SlNo,
                             list.Sex,
                             list.Street,
                             list.Village

                         });
            if (execInfo.Any())
            {
                return Ok(execInfo);
            }
            return NotFound();
        }

        //***   GET EXECUTANT DDL DATA *********//
        [HttpGet]
        [Route("{ackno}/execddllist")]
        public System.Collections.IEnumerable execddlist(string ackno)
        {

            //return db.OnlineExecutant 
            System.Collections.IEnumerable elist;
            //elist = db.OnlineExecutant
            //      .Where(b => b.Ackno == ackno);

            //elist = (from p in db.OnlineExecutant
            //         where p.Ackno == ackno
            //         select p);
            //.Select(x => new OnlineExecutant { Ackno = x.Ackno });

            //return elist;

            elist = (from p in db.Set<OnlineExecutant>()
                     where p.Ackno == ackno
                     select new { p.State, p.District, p.SubDivision, p.Village, p.Street, p.PostOffice, p.PinCode, p.PoliceSt }).AsEnumerable();
            //.Select(x => new OnlineExecutant { Ackno = x.Ackno });

            return elist;




            // Request.CreateResponse(HttpStatusCode.OK, online);
        }
        // post executantlist
        [HttpPost]
        [Route("postexecutant")]
        public async Task<IHttpActionResult> postexecutant([FromBody] IEnumerable<Executant> executantlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (Executant E in executantlist)
            {


                db.Executant.Add(E);

            }



            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {

                throw;


            }

            // return CreatedAtRoute("DefaultApi", new { controller = "postexecutant", id = executantlist[0].ackno }, executantlist);
            return Ok();
        }

        // Get Online Claimant list 
        [HttpGet]
        [Route("{ackno}/claimantlist")]
        public IHttpActionResult claimantlist(string ackno)
        {

            //return db.OnlineExecutant 
            //IEnumerable<OnlineClaimant> clist;
            var clist = db.OnlineClaimant
                        .Where(b => b.Ackno == ackno)
                        .Select(list => new
                        {
                            list.SlNo,
                            list.ClaimSurName,
                            list.ClaimMiddleName,
                            list.ClaimLastName,
                            list.Alias,
                            list.Aadhaar,
                            list.Mobile,
                            list.FatherSurName,
                            list.FatherMiddleName,
                            list.FatherLastName,
                            list.Sex,
                            list.Occupation
                        });


            if (clist.Any())
            {
                return Ok(clist);
            }
            else
                return NotFound();
        }
        //GET CLAIMANT INFO
        [HttpGet]
        [Route("{ts}/{tyear}/claimantInfo")]
        public IHttpActionResult getclaimantInfo(int ts, int tyear)
        {
            var claiminfo = db.Claimant
                         .Where(c => c.TSNo == ts && c.TSYear == tyear)
                         .Select(list => new
                         {
                             list.ClaimSurName,
                             list.ClaimMiddleName,
                             list.ClaimLastName,
                             list.FatherSurName,
                             list.FatherMiddleName,
                             list.FatherLastName,
                             list.SlNo,
                             list.Sex,
                             list.Street,
                             list.Village

                         });
            if (claiminfo.Any())
            {
                return Ok(claiminfo);
            }
            return NotFound();
        }
        // GET IDENTIFIER INFO
        [HttpGet]
        [Route("{ts}/{tyear}/identifierInfo")]
        public IHttpActionResult getidentifierInfo(int ts, int tyear)
        {
            var claiminfo = db.Identifier
                          .Where(c => c.TSNo == ts && c.TSYear == tyear)
                          .Select(list => new
                          {
                              list.IdentSurName,
                              list.IdentMiddleName,
                              list.IdentLastName,
                              list.FatherSurName,
                              list.FatherMiddleName,
                              list.FatherLastName,
                              list.SlNo,
                              list.Sex,
                              list.Street,
                              list.Village

                          });
            if (claiminfo.Any())
            {
                return Ok(claiminfo);
            }
            return NotFound();
        }

        //// SR APPLICATION STATUS
        ////[HttpPost]
        ////[Route("srupdate")]
        ////public async Task<IHttpActionResult> SRupdate()
        ////{
        ////    try
        ////    {
        ////        await();
        ////    }
        ////    catch (DbUpdateException e ) {

        ////}
        ////}
        // GET ONLINE IDENTIFIER LIST
        [HttpGet]
        [Route("{ackno}/identifierlist")]
        public IHttpActionResult identifierlist(string ackno)
        {



            var ilist = db.OnlineIdentifier
                         .Where(b => b.Ackno == ackno)
                         .Select(list => new
                         {
                             list.IdentSurName,
                             list.IdentMiddleName,
                             list.IdentLastName,
                             list.Alias,
                             list.Mobile,
                             list.Aadhaar,
                             list.FatherSurName,
                             list.FatherMiddleName,
                             list.FatherLastName,
                             list.Occupation,
                             list.SlNo,
                             list.Sex

                         });
            if (ilist.Any())
            {
                return Ok(ilist);
            }
            else return NotFound();

        }
        // GET ONLINE IDENTDDL LIST
        [HttpGet]
        [Route("{ackno}/identddllist")]
        public System.Collections.IEnumerable identddllist(string ackno)
        {

            System.Collections.IEnumerable iddlist;


            iddlist = (from p in db.Set<OnlineIdentifier>()
                       where p.Ackno == ackno
                       select new { p.State, p.District, p.SubDivision, p.Village, p.Street, p.PostOffice, p.PinCode, p.PoliceSt, p.Identify }).AsEnumerable();
            //.Select(x => new OnlineExecutant { Ackno = x.Ackno });

            return iddlist;


        }
        // GET CLAIMANT DDL LIST
        [HttpGet]
        [Route("{ackno}/claimddlist")]

        public System.Collections.IEnumerable claimddlist(string ackno)
        {

            System.Collections.IEnumerable cddlist;


            cddlist = (from p in db.Set<OnlineClaimant>()
                       where p.Ackno == ackno
                       select new { p.State, p.District, p.SubDivision, p.Village, p.Street, p.PostOffice, p.PinCode, p.PoliceSt }).AsEnumerable();
            //.Select(x => new OnlineExecutant { Ackno = x.Ackno });

            return cddlist;


        }

        //POST CLAIMANT DETAILS
        [Route("postClaimant")]
        public async Task<IHttpActionResult> postClaimant(IEnumerable<Claimant> claimantlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            foreach (Claimant c in claimantlist)
            {
                db.Claimant.Add(c);

            }

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {

                throw;


            }

            return Ok();
        }
        //POST IDENTIFIER DETAILS
        [Route("postIdentifier")]
        public async Task<IHttpActionResult> postIdentifier(IEnumerable<Identifier> identifierList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            foreach (Identifier i in identifierList)
            {
                db.Identifier.Add(i);

            }

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {

                throw;


            }

            return Ok();
        }

        # endregion

        #region APPLICATION UPDATE
        [HttpPost]
        [Route("applicationAdd")]
        public async Task<IHttpActionResult> addApplication(Application application)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //DateTime entrydate=DateTime.UtcNow;
            application.Entrydate = DateTime.UtcNow.ToString();
            int tsyear = DateTime.Now.Year;

            int? curTsno = db.Application
                .Where(a => a.sro == application.sro && a.TSYear == tsyear).Max(a => (int?)a.TSNo);
            application.TSNo = (curTsno ?? default(int)) + 1;
            application.TSYear = (short)tsyear;
            db.Application.Add(application);

           
            try
            {
                await db.SaveChangesAsync();
            }

            catch (DbUpdateException e)
            {
                return NotFound();
            }
            IEnumerable<int> transidlist = new List<int> { tsyear, application.TSNo };

            return Ok(transidlist);
            
        }

        [HttpPost]
        [Route("applicationEntered")]
        public async Task<IHttpActionResult> addApplnComplete(Application application)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //DateTime entrydate=DateTime.UtcNow;
            var query = db.Application
                .Where(a => a.sro == application.sro && a.TSYear == application.TSYear && a.TSNo == application.TSNo).SingleOrDefault();
           query.status="DataEntered,Verify";
           query.ackno = application.ackno;
            if (application.ackno != null)
            {
                // var stringackno=db.onlineapplication
                onlineapplication onlineApplication = db.onlineapplication
                                    .Where(o => SqlFunctions.StringConvert((double?)o.ackno).Trim() + o.sro + o.year == application.ackno).FirstOrDefault();
                onlineApplication.status = application.status;
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
        //SR approve application
        [HttpPost]
        [Route("updateApplication")]
        public async Task<IHttpActionResult> approve(ApplicationStatus application)
        {

            var appln = db.Application
                   .Where(a => a.TSNo == application.tsno && a.TSYear == application.tsyear && a.sro == application.sro).FirstOrDefault();
            appln.status = application.status;
            var reason = "plot";
            if (application.remarks.Length > 0)
            //if(reason.Length>0)
            {
                appln.remarks = application.remarks;
            }

            if (application.Ackno != null)
            {
                onlineapplication onlineApplication = db.onlineapplication
                                    .Where(o => (SqlFunctions.StringConvert((double)o.ackno).Trim()+""+o.sro+""+ o.year) == application.Ackno).SingleOrDefault();
                onlineApplication.status = application.status;
                if (application.remarks.Length > 0)
                {
                    onlineApplication.remarks = application.remarks;
                }
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

        ////Data entry applicaiton update
        //[Route("updateDeedStatus")]
        //public async Task<IHttpActionResult> updateDeedStatus(StatusObject statusObject)
        //{
        //    Deed d = db.Deed
        //           .Where(c => c.TSNo == statusObject.tsno && c.TSYear == statusObject.tsyear).FirstOrDefault();
        //    d.Status = statusObject.status;

        //    if (statusObject.Ackno != 0)
        //    {
        //        onlineapplication onlineApplication = db.onlineapplication
        //                            .Where(o => o.ackno == statusObject.Ackno).FirstOrDefault();
        //        onlineApplication.status = statusObject.status;
        //    }

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }

        //    catch (DbUpdateException e)
        //    {
        //        return NotFound();
        //    }

        //    return Ok();
        //}

        [Route("getDate")]
        public IHttpActionResult getDate()
        {
            var datenow = DateTime.UtcNow;
            datenow = datenow.AddDays(10);
            return Ok(datenow);
        }
        [Route("postDate")]
        public async Task<IHttpActionResult> postDate(Appointment appntObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Appointment.Add(appntObject);

            try
            {
                await db.SaveChangesAsync();
            }

            catch (DbUpdateException e)
            {
                return InternalServerError(e);
            }

            var appDate = from appln in db.Application
                          where appln.ackno != null
                          join oAppln in db.onlineapplication
                         // on new { ackno = appln.ackno, appln.sro } equals new { oAppln.ackno, oAppln.sro }
                         on appln.ackno equals (SqlFunctions.StringConvert((double)oAppln.ackno)+""+oAppln.sro+""+oAppln.year)
                          join appnt in db.Appointment
                          on new { appln.TSNo, appln.TSYear, appln.sro } equals new { appnt.TSNo, appnt.TSYear, appnt.sro }
                          select appnt;


            return Ok(appDate);
        }
        #endregion

        #region GENERATE TSNO TSYEAR
        [HttpPost]
        [Route("generateTS")]
        public IHttpActionResult generateTS([FromBody]string sro)
        {
            int tsyear = DateTime.Now.Year;

            int? curTsno = db.Application
                .Where(a => a.sro == sro && a.TSYear == tsyear).Max(a => (int?)a.TSNo);
            int nextcurTsno = (curTsno ?? default(int)) + 1;
            IEnumerable<int> transidlist = new List<int> { tsyear, nextcurTsno };

            return Ok(transidlist);
        }

        #endregion

        #region OnlineDeedEntry
        [Route("getOnlineData")]
        [HttpPost]
        public IHttpActionResult getOnlineData([FromBody] string ackno)
        {
            var onlinedata = from appln in db.Application
                             where (appln.ackno != null ? appln.ackno == ackno : true) && appln.status == "DateFixed"
                             join oAppln in db.onlineapplication
                             on appln.ackno equals SqlFunctions.StringConvert((double)oAppln.ackno).Trim()+oAppln.sro+oAppln.year into a
                            // on new { ackno = appln.ackno.Value, appln.sro } equals new { oAppln.ackno, oAppln.sro } into a
                             from x in a.Take(1)
                             select new
                             {
                                 ackno = appln.ackno,
                                 sro = appln.sro,
                                 ts = appln.TSNo,
                                 tsyear = appln.TSYear,
                                 trans_code = appln.trans_maj_code,
                                 status = appln.status

                             };

            if (onlinedata.Any())
            {
                return Ok(onlinedata);


            }
            return NotFound();
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using eSiroi.Resource.Entities;
//using eSiroi.Resource.Migrations.Entities;
//using eSiroi.Resource.Repository;
using System.Web.Http.Description;
using System.Threading.Tasks;
using System.Web.Http.Results;
using eSiroi.Resource.Models;

namespace eSiroi.Resource.Controllers
{
    // [RoutePrefix("api/ApplyRegistrationController")]
    public class ApplyRegistrationController : ApiController
    {
        private eSiroiReSrcDbContext db = new eSiroiReSrcDbContext();
        
        
        //UPDATE APPLICATION STATUS

        //[HttpPost]
        [Route("api/ApplyRegistrationController/updateAppln")]
        public IHttpActionResult updateAppln([FromBody]int ackno)
        {
            var query = db.onlineapplication
                      .Where(a => a.ackno == ackno)
                      .First();


            try
            {
                query.status = "Applied";
                db.SaveChanges();
                return Ok();
            }
                
           catch(Exception){
               return NotFound();
           }
            

                    
        }
        
        //get SRO 
        [HttpGet]
        [Route("api/ApplyRegistrationController/getSRO")]
        public IHttpActionResult getSRO()
        {
            var sro = db.RegistarOffice;
            if(sro.Any())
            {
                return Ok(sro);

            }
            return NotFound();
        }

        //get SroName
        [HttpGet]
        [Route("api/ApplyRegistrationController/{officeCode}/getSroName")]

        public IHttpActionResult getSroName(short officeCode)
        {
            var query = db.RegistarOffice
                       .Where(R => R.RegOfficeCode == officeCode)
                       .Select(c=>c.RegOfficeName);
            if (query.Any())
            {
                return Ok(query);

            }
            return NotFound();
        }

        // Get States
        [HttpGet]
        [Route("api/ApplyRegistrationController/state")]
        public IEnumerable<State> states()
        {
            return db.State;
        }
        // api/disricts
        [HttpGet]
        [Route("api/ApplyRegistrationController/{DistCode:int}/districts")]
        public IEnumerable<District> Districts(int distcode)
        {
            return db.Districts;
        }
        
        // Get  Revenue subdivisions
        [HttpGet]
        [Route("api/ApplyRegistrationController/Revsubdivision")]
        public IEnumerable<SubDivision> Revsubdivision()
        {

            return db.SubDivision;


        }
        //GET census subdivision
        [HttpGet]
        [Route("api/ApplyRegistrationController/subdivisions")]
        public IEnumerable<CensusSubDivision> CensusSubDivision()
        {

            return db.CensusSubDivisions;

        }
//        //GET census village
        [HttpGet]
        [Route("api/ApplyRegistrationController/villages")]
        public IEnumerable<censusvillage> villages ()
            {
                return db.CensusVillage;


            }
        // GET POSTOFFICES
        [HttpGet]
        [Route("api/ApplyRegistrationController/postoffices")]
            public IEnumerable<PostOffice> postoffices ()

            {
                return db.PostOffice;
            }
       
        //Get MajorTrans_code
        [HttpGet]
        [Route("api/ApplyRegistrationController/MajorTrans_code")]
        public IEnumerable<MajorTrans_code> MajorTrans_code()
        {
            return db.MajorTrans_code;
        }
        [HttpGet]
        [Route("api/ApplyRegistrationController/circle")]
        public IEnumerable<Circle> Circle()
        {
            return db.Circle;
        }
        [HttpGet]
        [Route("api/ApplyRegistrationController/RevVillage")]
        public IEnumerable<RevVillage> RevVillage()
        {
            return db.RevVillage;
        }

        [HttpGet]
        [Route("api/ApplyRegistrationController/{maj_code}/trans_name")]
        public IHttpActionResult MajorTrans_name(String maj_code)
        {

            var query = db.MajorTrans_code
                      .Where(m => m.tran_maj_code == maj_code)
                      .Select(tn => tn.tran_name);
            if(query.Any())
            {
                return Ok(query);

            }
            return NotFound();
           

        }

        [HttpGet]
        [Route("api/ApplyRegistrationController/{sro}/ackno")]
        public IHttpActionResult Ackno(String sro)
        {
            
            var application = from s in db.onlineapplication
                              where s.sro == sro  && s.ackno == (db.onlineapplication.Select(s1 => s1.ackno).Max())  
                              select s;
           if (application.Any())
             return Ok(application);  
           return NotFound();
           

            // Request.CreateResponse(HttpStatusCode.OK, online);
        }

        [HttpGet]
        [Route("api/ApplyRegistrationController/{ackno}/excutantlist")]
        public IEnumerable <OnlineExecutant> excutantlist(string ackno)
        {

            //return db.OnlineExecutant 
            IEnumerable<OnlineExecutant> elist;
            elist = db.OnlineExecutant
                  .Where(b => b.Ackno == ackno);
                  
            //elist = (from p in db.OnlineExecutant
            //         where p.Ackno == ackno
            //         select p);
            //.Select(x => new OnlineExecutant { Ackno = x.Ackno });

            //return elist;

            //elist = (from p in db.Set<OnlineExecutant>()
            //         where p.Ackno == ackno
            //         select new { Ackno = p.Ackno }).AsEnumerable();
            //         //.Select(x => new OnlineExecutant { Ackno = x.Ackno });

            return elist;
           
           


            // Request.CreateResponse(HttpStatusCode.OK, online);
        }

        //***   GET EXECUTANT DDL DATA *********//
        [HttpGet]
        [Route("api/ApplyRegistrationController/{ackno}/execddllist")]
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
                     select new { p.State, p.District,p.SubDivision,p.Village,p.PostOffice,p.PinCode,p.PoliceSt}).AsEnumerable();
            //.Select(x => new OnlineExecutant { Ackno = x.Ackno });

            return elist;




            // Request.CreateResponse(HttpStatusCode.OK, online);
        }

        [HttpPost]
        [Route("api/ApplyRegistrationController/postapplication")]
        public async Task<IHttpActionResult> PostOnlineApplication([FromBody] onlineapplication   onlineapplication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            onlineapplication.date = DateTime.Now.ToShortDateString();

            db.onlineapplication.Add(onlineapplication);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (onlineapplicationExists(onlineapplication.ackno))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { controller = "onlineapplication", id = onlineapplication.ackno }, onlineapplication);
        }

        
        //Add Online application
       [HttpPost]
       [Route("api/ApplyRegistrationController/addOapplication")]
        public async Task<IHttpActionResult> addapplication(onlineapplication oAppln)
        {

            int  maxackno =Convert.ToInt32( db.onlineapplication
                         .Where(o => o.sro == oAppln.sro && o.year == DateTime.Now.Year.ToString())
                         .Max(o => (int?)o.ackno));
            
            oAppln.date = DateTime.Now.ToShortDateString();
            oAppln.year = DateTime.Now.Year.ToString();
            oAppln.status = "incomplete";
            
           int newackno=maxackno + 1;
            //while (onlineapplicationExists(newackno))
            //{
            //    newackno = newackno + 1;
            //}

            oAppln.ackno = newackno;
            db.onlineapplication.Add(oAppln);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {

                return Conflict();

            }
           //var returnAckno = maxackno.ToString() + oAppln.sro + oAppln.year + 
            OnlineApplnId OApplnReturnModel = new OnlineApplnId();
            OApplnReturnModel.ackno = newackno;
            OApplnReturnModel.sro = oAppln.sro;
            OApplnReturnModel.year = oAppln.year;
            return Ok(OApplnReturnModel);
       }
        [HttpPost]
        [Route("api/ApplyRegistrationController/postplot")]
        public async Task<IHttpActionResult> postplot([FromBody] onlinePlot plot)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //var currAckno = getAck();
            ////var currAckno = db.onlineapplication.Where(s=>s.sro).Max(s => s.ackno);
            //plot.ackno = currAckno + 1;
            ////db.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            db.onlinePlot.Add(plot);
             try
            {
                await db.SaveChangesAsync();
            }
             catch (DbUpdateException)
             {
                
                 throw;
                
             }
             return Ok(plot.ackno);
        }

        // POST EXECUTANT LIST
        [HttpPost]
        [Route("api/ApplyRegistrationController/postexecutant")]
        public async Task<IHttpActionResult> postexecutant([FromBody] IEnumerable <OnlineExecutant>  executantlist)
         {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            foreach ( OnlineExecutant E in executantlist) {


                 db.OnlineExecutant.Add(E);

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

        // POST CLAIMANT LIST
        [HttpPost]
        [Route("api/ApplyRegistrationController/postclaimant")]
        public async Task<IHttpActionResult> postclaimant([FromBody] IEnumerable<OnlineClaimant> claimantlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (OnlineClaimant C in claimantlist)
            {


                db.OnlineClaimant.Add(C);

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
        // POST IDENTIFIER LIST
        [HttpPost]
        [Route("api/ApplyRegistrationController/postidentifier")]
        public async Task<IHttpActionResult> postidentifier([FromBody] IEnumerable<OnlineIdentifier> identifierlist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (OnlineIdentifier I in identifierlist)
            {


                db.OnlineIdentifier.Add(I);

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

        #region helper functions
        private bool onlineapplicationExists(int id)
        {
            return db.onlineapplication.Count(e => e.ackno == id) > 0;
        }

        private IQueryable<int> getackno(String sro)
        {
            return from s in db.onlineapplication
                   where s.sro == sro
                   select s.ackno;

        }
        //private int getAck()
        //{
        //    try
        //    {
        //        int currAckno = db.onlinePlot.Max(s => s.ackno);
        //        return currAckno;
        //    }
        //    catch (Exception)
        //    {
        //        return 0;
        //    }

        //}
        #endregion

        #region test
        [HttpGet]
         [Route("api/ApplyRegistrationController/test")]
        public int test()
        {
           
          int maxackno1 = Convert.ToInt32(db.onlineapplication
                        .Where(o => o.sro == "1" && o.year == DateTime.Now.Year.ToString())
                        .Max(o => (int?)o.ackno));
            int newackno1 = maxackno1 + 1;
            return (newackno1);
           
        }
        #endregion
    }
}

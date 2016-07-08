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
using System.Data.Entity.SqlServer;

namespace eSiroi.Resource.Controllers
{
    [RoutePrefix("api/Public")]
    public class PublicController : ApiController
    {
        private eSiroiReSrcDbContext db = new eSiroiReSrcDbContext();
        [HttpGet]
        [Route("{appln}/applnStatus")]
        public IHttpActionResult getAppln(string appln)
        {
            var query = db.onlineapplication
                        .Where(a => SqlFunctions.StringConvert((double)a.ackno).Trim() + "" + a.sro + "" + a.year == appln)
                        .Join(db.RegistarOffice, a => a.sro, ro => ro.RegOfficeCode.ToString(), (a, ro) => new { a = a, ro = ro })
                        .Join(db.MajorTrans_code, apln => apln.a.trans_maj_code, trans => trans.tran_maj_code, (apln, trans) => new { apln, trans })
                        .Select(
                        OnlineAppln => new
                        {
                            ackno = OnlineAppln.apln.a.ackno,
                            year = OnlineAppln.apln.a.year,
                            sro = OnlineAppln.apln.ro.RegOfficeName,
                            roCode=OnlineAppln.apln.ro.RegOfficeCode,
                            trans_maj_code=OnlineAppln.trans.tran_maj_code,
                            trans_name = OnlineAppln.trans.tran_name,
                            date = OnlineAppln.apln.a.date,
                            status = OnlineAppln.apln.a.status
                        }

                        );
                            
            if (query.Any())
            {
                return Ok(query);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("scheduledDate")]
        public IHttpActionResult getSchedules([FromBody]string ackno)
        {
            var query = db.Application
                       .Where(a => a.status == "DateFixed" && a.ackno==ackno)
                       .Join(db.Appointment,
                       a => new { a.TSNo, a.TSYear, a.sro },
                       appnt => new { appnt.TSNo, appnt.TSYear, appnt.sro },
                       (t1, t2) => new { t1.TSNo, t1.TSYear, t1.sro, t1.ackno, t2.date1, t2.date2, t2.date3 });
            if (query.Any())
            {
                return Ok(query);
            }
            return NotFound();
        }
        [HttpPost]
        [Route("getAckn")]
        public IHttpActionResult printAcknowledgement(OnlineApplnId appln)
        {
            var query = db.onlineapplication
                      .Where(a => a.ackno == appln.ackno && a.sro == appln.sro && a.year == appln.year)
                      .Select(list=>new{
                          list.ackno,
                          list.date,
                          list.year,
                          list.sro
                      });
            if (query.Any())
            {
                return Ok(query);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("OApplnModel")]
        public IHttpActionResult OnlineApplicationModel([FromBody]string ackno)
        {
            var query = db.onlineapplication
                      .Where(a => SqlFunctions.StringConvert((double)a.ackno).Trim()+""+a.sro+""+a.year == ackno)
                      .Select(list => new
                      {
                          list.ackno,
                          list.sro,
                          list.trans_maj_code,
                          list.date,
                          list.year
                      });
            if (query.Any())
            {
                return Ok(query);
            }
            return NotFound();
        }
    }
}

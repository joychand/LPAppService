using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http.Filters;

namespace eSiroi.Resource.ApiFilter
{
    public class NoCacheHeaderFilter:ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null) // can be null when exception happens
            {
                actionExecutedContext.Response.Headers.CacheControl =
                    new CacheControlHeaderValue { NoCache = true, NoStore = true, MustRevalidate = true };
                actionExecutedContext.Response.Headers.Pragma.Add(new NameValueHeaderValue("no-cache"));

                if (actionExecutedContext.Response.Content != null) // can be null (for example HTTP 400)
                {
                    //actionExecutedContext.Response.Content.Headers.Expires = DateTimeOffset.UtcNow;
                    actionExecutedContext.Response.Content.Headers.Expires = DateTimeOffset.Now.AddDays(-1);
                }
            }
        }
    }
}
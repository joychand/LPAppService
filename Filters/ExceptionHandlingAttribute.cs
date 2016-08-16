using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace LPAppService.Filters
{
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is HttpRequestException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("BadRequest"),
                    ReasonPhrase = "BadRequest"
                });

            }
            else if (context.Exception is HttpException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("ResourceNotFound"),
                    ReasonPhrase = "ResourceNotFound"
                });
            }
            else
            ////Log Critical errors
            //Debug.WriteLine(context.Exception);

                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("An error occurred, please try again or contact the administrator."),
                    ReasonPhrase = "Critical Exception"
                });
        }
    }
}
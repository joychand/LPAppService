using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace LPAppService.Filters
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            if (context.Exception is ArgumentNullException)
            {
                var result = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent(context.Exception.Message),
                    //Content = new StringContent("ArgumenNullException"),
                    ReasonPhrase = "Bad Request"
                };

                context.Result = new ExceptionHandlerResult(context.Request, result);
            }
            else if (context.Exception is UriFormatException)
            {
                var result = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(context.Exception.Message),
                    //Content = new StringContent("ArgumenNullException"),
                    ReasonPhrase = "ResourceNotFound"
                };
                context.Result = new ExceptionHandlerResult(context.Request, result);
            }
            else if (context.Exception is UnsupportedMediaTypeException)
            {
                var result = new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType)
                {
                    Content = new StringContent("ContentTypeNotSupported"),
                    //Content = new StringContent("ArgumenNullException"),
                    ReasonPhrase = "ContentTypeNotSupported"
                };
                context.Result = new ExceptionHandlerResult(context.Request, result);
            }

            else
            {
                var result = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                   // Content = new StringContent(context.Exception.Message),
                    Content = new StringContent("An error occurred, please try again or contact the administrator."),
                    ReasonPhrase = "Critical Error"
                };

                context.Result = new ExceptionHandlerResult(context.Request, result);
            }
            //else
            //{
            //    // Handle other exceptions, do other things
            //}
        }

        public class ExceptionHandlerResult : IHttpActionResult
        {
            private HttpRequestMessage _request;
            private HttpResponseMessage _httpResponseMessage;


            public ExceptionHandlerResult(HttpRequestMessage request, HttpResponseMessage httpResponseMessage)
            {
                _request = request;
                _httpResponseMessage = httpResponseMessage;
            }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                return Task.FromResult(_httpResponseMessage);
            }
        }

        //public class ArgumentNullResult : IHttpActionResult
        //{
        //    private HttpRequestMessage _request;
        //    private HttpResponseMessage _httpResponseMessage;


        //    public ArgumentNullResult(HttpRequestMessage request, HttpResponseMessage httpResponseMessage)
        //    {
        //        _request = request;
        //        _httpResponseMessage = httpResponseMessage;
        //    }

        //    public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        //    {
        //        return Task.FromResult(_httpResponseMessage);
        //    }
        //}

        //public class UriFormatExceptionResult : IHttpActionResult
        //{
        //    private HttpRequestMessage _request;
        //    private HttpResponseMessage _httpResponseMessage;


        //    public UriFormatExceptionResult(HttpRequestMessage request, HttpResponseMessage httpResponseMessage)
        //    {
        //        _request = request;
        //        _httpResponseMessage = httpResponseMessage;
        //    }

        //    public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        //    {
        //        return Task.FromResult(_httpResponseMessage);
        //    }
        //}

        //public class InternalServerExceptionResult : IHttpActionResult
        //{
        //    private HttpRequestMessage _request;
        //    private HttpResponseMessage _httpResponseMessage;


        //    public InternalServerExceptionResult(HttpRequestMessage request, HttpResponseMessage httpResponseMessage)
        //    {
        //        _request = request;
        //        _httpResponseMessage = httpResponseMessage;
        //    }

        //    public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        //    {
        //        return Task.FromResult(_httpResponseMessage);
        //    }
        //}
    }
}
﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace LPAppService.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var errormessage = "Input Parameters are invalid";
            if (actionContext.ModelState.IsValid == false)
            {
                //actionContext.Response = actionContext.Request.CreateErrorResponse(
                //    HttpStatusCode.BadRequest, actionContext.ModelState);

                actionContext.Response = actionContext.Request.CreateErrorResponse(
                   HttpStatusCode.BadRequest, errormessage);
            }
        }
    }
}
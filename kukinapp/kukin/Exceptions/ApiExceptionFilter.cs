using kukin.Services.Exceptions;
using kukin.Services.Exceptions.Interfaces;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;

namespace kukin.Exceptions
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private readonly TelemetryClient _telemetry;

        public ApiExceptionFilter(TelemetryClient telemetry)
        {
            _telemetry = telemetry ?? throw new ArgumentNullException(nameof(telemetry));
        }

        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is BusinessException bEx)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = CreateJsonResult(bEx);
            }
            else if (context.Exception is NotFoundException nEx)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                context.Result = CreateJsonResult(nEx);
            }
            else if (context.Exception is ForbiddenException fEx)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                context.Result = CreateJsonResult(fEx);
            }
            else
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result = CreateJsonResult(context.Exception);
            }

            base.OnException(context);
        }

        /// <summary>
        /// Returns Json Result with Error Response Object.
        /// </summary>
        /// <param name="ex">Exception Object</param>
        /// <returns>Json Result with Error Response Object</returns>
        private JsonResult CreateJsonResult(Exception ex)
        {
            ErrorResponse errorResponse;
            if (ex is IKukinException kukinException)
            {
                errorResponse = new ErrorResponse()
                {
                    ErrorCode = kukinException.ErrorCode,
                    ErrorMessage = ex.Message
                };
            }
            else
            {
                errorResponse = new ErrorResponse()
                {
                    ErrorMessage = "An Unhandled Exception has occurred. Please try again later.",
                    DetailedDescription = ex.Message
                };
            }

            _telemetry.TrackException(ex);
            
            return new JsonResult(errorResponse);
        }
    }
}

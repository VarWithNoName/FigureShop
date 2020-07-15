using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Catalog.API.Middleware
{
    public class ExceptionMiddleware
    {
        readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            if (next == null) throw new ArgumentNullException(nameof(next));
            _next = next;
            _logger = loggerFactory.CreateLogger<ExceptionMiddleware>();
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong: {Exception}", ex);

                httpContext.Response.ContentType = "application/json"; //default retrun type
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await httpContext.Response.WriteAsync("Something went wrong.");
                //var message = new BaseResponse()
                //{
                //    Status = IaaStatus.REJECT,
                //    RejectReasonCode = FailureCode.SystemError,
                //    RejectReasonDescription = new List<ValidationError>
                //    {
                //        new ValidationError
                //        {
                //            Messages = new List<string>
                //            {
                //                "Internal Error"
                //            }
                //        }
                //    }
                //};

                //var foundReturnType = httpContext.Request.Headers.TryGetValue("Accept", out StringValues acceptheaders);
                //if (foundReturnType)
                //{
                //    var acceptheader = acceptheaders.FirstOrDefault();
                //    if (acceptheader != null)
                //    {
                //        httpContext.Response.ContentType = acceptheader;
                //        if (acceptheader.Contains("xml", StringComparison.OrdinalIgnoreCase))
                //        {
                //            await httpContext.Response.WriteAsync(ToXml(message));
                //        }
                //        else
                //        {
                //            await httpContext.Response.WriteAsync(ToJson(message));
                //        }
                //    }
                //}
            }
        }

        //private class ErrorResponse
        //{
        //    public string[] Messages { get; set; }

        //    public object DeveloperMessage { get; set; }

        //}
        //private string ToJson(object obj)
        //{
        //    return JsonConvert.SerializeObject(obj);
        //}

        //private string ToXml(object obj)
        //{
        //    XmlSerializer serializer = new XmlSerializer(obj.GetType());
        //    using (StringWriter writer = new StringWriter())
        //    {
        //        serializer.Serialize(writer, obj);
        //        return writer.ToString();
        //    }
        //}
    }
}

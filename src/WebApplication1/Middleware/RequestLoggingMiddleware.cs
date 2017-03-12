using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var startTime = DateTime.UtcNow;

            //Workaround for issue with body stream
            //http://stackoverflow.com/questions/37855384/how-to-log-the-http-response-body-in-asp-net-core-1-0
            var initalBody = context.Request.Body;

            string body;
            using (var bodyReader = new StreamReader(context.Request.Body))
            {
                body = await bodyReader.ReadToEndAsync();
            }

            context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(body));
            await _next.Invoke(context);

            //Workaround - return back to original Stream
            context.Request.Body = initalBody;

            var logTemplate = @"
Client IP: {clientIP}
Request path: {requestPath}
Request content type: {requestContentType}
Request content length: {requestContentLength}
Request content: {requestContentBody}
Start time: {startTime}";

            _logger.LogInformation(logTemplate,
                context.Connection.RemoteIpAddress.ToString(),
                context.Request.Path,
                context.Request.ContentType,
                context.Request.ContentLength,
                body,
                startTime);
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SkillIT_API.Middleware
{
    /// <summary>
    /// Middleware to log all HTTP requests and responses for debugging and monitoring
    /// </summary>
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

        public RequestResponseLoggingMiddleware(
            RequestDelegate next,
            ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            var requestId = Guid.NewGuid().ToString();

            // Log request
            await LogRequest(context, requestId);

            // Capture original response stream
            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                try
                {
                    await _next(context);
                }
                finally
                {
                    stopwatch.Stop();

                    // Log response
                    await LogResponse(context, requestId, stopwatch.ElapsedMilliseconds);

                    // Copy response back to original stream
                    await responseBody.CopyToAsync(originalBodyStream);
                }
            }
        }

        private async Task LogRequest(HttpContext context, string requestId)
        {
            try
            {
                context.Request.EnableBuffering();
                var body = await ReadStreamAsync(context.Request.Body);
                context.Request.Body.Position = 0;

                _logger.LogInformation(
                    "HTTP Request [{RequestId}]: {Method} {Scheme}://{Host}{Path}{QueryString} | Body: {Body}",
                    requestId,
                    context.Request.Method,
                    context.Request.Scheme,
                    context.Request.Host,
                    context.Request.Path,
                    context.Request.QueryString,
                    string.IsNullOrWhiteSpace(body) ? "[empty]" : body
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error logging request for RequestId: {RequestId}", requestId);
            }
        }

        private async Task LogResponse(HttpContext context, string requestId, long elapsedMs)
        {
            try
            {
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var body = await ReadStreamAsync(context.Response.Body);
                context.Response.Body.Seek(0, SeekOrigin.Begin);

                _logger.LogInformation(
                    "HTTP Response [{RequestId}]: Status: {StatusCode} | Duration: {Duration}ms | Body: {Body}",
                    requestId,
                    context.Response.StatusCode,
                    elapsedMs,
                    string.IsNullOrWhiteSpace(body) ? "[empty]" : body
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error logging response for RequestId: {RequestId}", requestId);
            }
        }

        private static async Task<string> ReadStreamAsync(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            using var reader = new StreamReader(stream, Encoding.UTF8, leaveOpen: true);
            var content = await reader.ReadToEndAsync();
            stream.Seek(0, SeekOrigin.Begin);
            return content;
        }
    }
}

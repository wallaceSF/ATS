using Microsoft.AspNetCore.Diagnostics;

namespace ATSControlSystem.Api.Middleware
{
    public class RequestResponseLogMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            HttpRequest request = httpContext.Request;

            var requestJson = await ReadBodyFromRequest(request);

            Console.WriteLine(requestJson);

            HttpResponse response = httpContext.Response;
            var originalResponseBody = response.Body;
            using var newResponseBody = new MemoryStream();
            response.Body = newResponseBody;

            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            newResponseBody.Seek(0, SeekOrigin.Begin);
            var responseBodyText = await new StreamReader(response.Body).ReadToEndAsync();

            newResponseBody.Seek(0, SeekOrigin.Begin);
            await newResponseBody.CopyToAsync(originalResponseBody);

            Console.WriteLine(responseBodyText);

            var contextFeature = httpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (contextFeature != null && contextFeature.Error != null)
            {
                Exception exception = contextFeature.Error;
                Console.WriteLine(exception);
            }
        }

        private async Task<string> ReadBodyFromRequest(HttpRequest request)
        {
            request.EnableBuffering();
            using var streamReader = new StreamReader(request.Body, leaveOpen: true);
            var requestBody = await streamReader.ReadToEndAsync();

            request.Body.Position = 0;
            return requestBody;
        }
    }
}
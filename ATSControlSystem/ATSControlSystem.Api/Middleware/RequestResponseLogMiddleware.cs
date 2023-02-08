using Microsoft.AspNetCore.Diagnostics;
using Serilog.Context;
using Serilog.Core;
using Newtonsoft.Json.Linq;

namespace ATSControlSystem.Api.Middleware
{
    public class RequestResponseLogMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private static object DeserializeAsObject(string json)
        {
            return DeserializeAsObjectCore(JToken.Parse(json));
        }

        private static object DeserializeAsObjectCore(JToken token)
        {
            return token.Type switch
            {
                JTokenType.Object => token.Children<JProperty>()
                    .ToDictionary(prop => prop.Name, prop => DeserializeAsObjectCore(prop.Value)),
                JTokenType.Array => token.Select(DeserializeAsObjectCore).ToList(),
                _ => ((JValue)token).Value
            };
        }

        public async Task InvokeAsync(HttpContext httpContext, Logger logger)
        {
            HttpRequest request = httpContext.Request;

            var requestJson = await ReadBodyFromRequest(request);

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
                LogContext.PushProperty("RequestBody", DeserializeAsObject(requestJson), true);
                LogContext.PushProperty("Exception", exception, true);

                logger.Error("Request To ATS");
                Console.WriteLine(exception);
            }

            newResponseBody.Seek(0, SeekOrigin.Begin);
            var responseBodyText = await new StreamReader(response.Body).ReadToEndAsync();

            newResponseBody.Seek(0, SeekOrigin.Begin);
            await newResponseBody.CopyToAsync(originalResponseBody);

            LogContext.PushProperty("RequestBody", DeserializeAsObject(requestJson), true);
            LogContext.PushProperty("ResponseBody", DeserializeAsObject(responseBodyText), true);

            logger.Information("Request To ATS");

            var contextFeature = httpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (contextFeature != null && contextFeature.Error != null)
            {
                Exception exception = contextFeature.Error;
                LogContext.PushProperty("RequestBody", DeserializeAsObject(requestJson), true);
                LogContext.PushProperty("Exception", exception, true);

                logger.Error("Request To ATS");
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
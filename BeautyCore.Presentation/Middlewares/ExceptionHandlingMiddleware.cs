using BeautyCore.Application.Common.Models;
using FluentValidation;
using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Hosting;

namespace BeautyCore.Presentation.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var errorDetails = new ErrorDetails
            {
                Message = "İşlem sırasında bir hata oluştu."
            };

            switch (exception)
            {
                case ValidationException valEx:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorDetails.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorDetails.Message = "Veri doğrulama başarısız.";
                    errorDetails.Errors = valEx.Errors.Select(x => x.ErrorMessage);
                    _logger.LogWarning(exception, "Doğrulama hatası: {TraceId}", context.TraceIdentifier);
                    break;

                case KeyNotFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorDetails.StatusCode = (int)HttpStatusCode.NotFound;
                    errorDetails.Message = "Aranan kayıt sistemde bulunamadı.";
                    _logger.LogInformation(exception, "Kayıt bulunamadı: {TraceId}", context.TraceIdentifier);
                    break;

                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorDetails.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorDetails.Message = "Sunucu tarafında bir hata oluştu.";
                    _logger.LogError(exception, "Beklenmedik hata: {TraceId}", context.TraceIdentifier);
                    break;
            }

            // Return details only if in Development AND response is 500
            var responsePayload = new
            {
                statusCode = context.Response.StatusCode,
                message = errorDetails.Message,
                errors = errorDetails.Errors,
                traceId = context.TraceIdentifier,
                details = (_env.IsDevelopment() && context.Response.StatusCode == (int)HttpStatusCode.InternalServerError)
                          ? exception.ToString()
                          : null
            };

            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = false
            };

            var json = JsonSerializer.Serialize(responsePayload, jsonOptions);
            await context.Response.WriteAsync(json);
        }
    }
}

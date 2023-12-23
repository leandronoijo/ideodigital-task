using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

public static class ErrorHandlerInitializer
{
    public static void Initialize(WebApplication app)
    {
        app.UseExceptionHandler(a => a.Run(async context =>
        {
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature?.Error;

            var logger = context.RequestServices.GetService<ILogger<Program>>();
            logger.LogError(exception, "An unhandled exception has occurred");

            var result = JsonSerializer.Serialize(new { error = "An error occurred while processing your request." });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync(result);

            if(app.Environment.IsDevelopment())
            {
                throw exception;
            }
        }));
    }
}
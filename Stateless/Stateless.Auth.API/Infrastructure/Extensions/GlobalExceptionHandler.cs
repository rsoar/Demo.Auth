using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using Stateless.Auth.API.Core.Exceptions;

namespace Stateless.Auth.API.Infrastructure.Extensions
{
    public class ApiResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string? Details { get; set; }
    }

    public static class GlobalExceptionHandler
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder application, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            application.UseExceptionHandler(configure =>
            {
                configure.Run(async context =>
                {
                    var excHandler = context.Features.Get<IExceptionHandlerFeature>();

                    if (excHandler != null)
                    {
                        ILogger logger = loggerFactory.CreateLogger("GlobalExceptionHandler");

                        ApiResult result = new();

                        if (excHandler.Error is ValidationException valExc)
                        {
                            context.Response.StatusCode = valExc.StatusCode;
                            result.StatusCode = valExc.StatusCode;
                            result.Message = valExc.Message;

                            if (env.IsDevelopment())
                            {
                                result.Details = valExc.ToString();
                            }

                            logger.LogError($"ValidationException was thrown: \n{result}");
                        }
                        else if (excHandler.Error is Exception unexpectedExc)
                        {
                            result.StatusCode = StatusCodes.Status500InternalServerError;
                            result.Message = unexpectedExc.Message;

                            if (env.IsDevelopment())
                            {
                                result.Details = unexpectedExc.ToString();
                            }

                            logger.LogError($"An unexpected exception was thrown: \n{result}");
                        }

                        context.Response.ContentType = "application/problem+json";
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
                    }
                });
            });
        }
    }
}

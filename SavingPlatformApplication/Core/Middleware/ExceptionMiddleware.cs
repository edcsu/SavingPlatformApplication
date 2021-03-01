using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SavingPlatformApplication.Core.Exceptions;
using Serilog;

namespace SavingPlatformApplication.Core.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)

            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            Log.Error($"{ex}");
            var message = "Oops something went wrong!";
            switch (ex)
            {
                case ClientSideException _:
                    context.Response.StatusCode = 400;
                    message = ex.Message;
                    break;
                case ModelStateException _:
                    context.Response.StatusCode = 400;
                    message = ex.Message;
                    break;
                case DbUpdateException _:
                    context.Response.StatusCode = 500;
                    message = ex.Message;
                    break;
                default:
                    context.Response.StatusCode = 500;
                    break;
            }

            context.Response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(new
            {
                message
            });
            return context.Response.WriteAsync(result);
        }
    }
}

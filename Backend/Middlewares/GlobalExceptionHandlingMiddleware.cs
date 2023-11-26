using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Backend.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        // private readonly RequestDelegate _next;

        // public GlobalExceptionHandlingMiddleware(RequestDelegate next)
        // {
        //     this._next = next;
        // }

        // public async Task InvokeAsync(HttpContext context)
        // {
        //     try
        //     {
        //         // Call the next delegate/middleware in the pipeline
        //         await _next(context);
        //     }
        //     catch (Exception ex)
        //     {
        //         // Handle the exception
        //         // await HandleExceptionAsync(context, ex);
        //         Console.WriteLine(ex.Message);
        //         context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //     }
        // }



        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                // Call the next delegate/middleware in the pipeline
                await next(context);
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    context.Response.ContentType = "application/problem+json";
                    await context.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = context.Response.StatusCode,
                        Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                        Title = "Not Found",
                        Detail = ex.Message,
                    });
                }
                else if (ex is InvalidException)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.ContentType = "application/problem+json";
                    await context.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = context.Response.StatusCode,
                        Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                        Title = "Bad Request",
                        Detail = ex.Message,
                    });
                }
                else
                {
                    // Log the unexpected exception
                    Console.WriteLine($"Unexpected error: {ex}");

                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/problem+json";

                    await context.Response.WriteAsJsonAsync(new ProblemDetails
                    {
                        Status = context.Response.StatusCode,
                        Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                        Title = "Internal Server Error",
                        Detail = "An unexpected error occurred.",
                    });
                }
            }
        }




        public async Task InvokeAsyncOld(HttpContext context, RequestDelegate next)
        {
            try
            {
                // Call the next delegate/middleware in the pipeline
                await next(context);
            }
            catch (Exception ex)
            {

                if (ex is NotFoundException)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    await context.Response.WriteAsJsonAsync(new { message = ex.Message });
                    return;
                }
                else if (ex is InvalidException)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await context.Response.WriteAsJsonAsync(new { message = ex.Message });
                    return;
                }

                // Handle the exception
                // await HandleExceptionAsync(context, ex);
                Console.WriteLine("==========================================================================");
                Console.WriteLine(ex.Message);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails problemDetails = new ProblemDetails
                {
                    Status = context.Response.StatusCode,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                    Title = "Internal Server Error",
                    Detail = ex.Message,
                };

                // string json = Newtonsoft.Json.JsonConvert.SerializeObject(problemDetails);
                // context.Response.ContentType = "application/problem+json";

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
    }
}
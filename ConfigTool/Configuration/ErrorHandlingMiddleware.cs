using System;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ConfigTool.Configuration
{
  public class ErrorHandlingMiddleware
  {
    private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
      try
      {
        await _next.Invoke(context);
      }
      catch (Exception ex)
      {
        await HandleExceptionAsync(context, ex);
      }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
      string message;
      var statusCode = HttpStatusCode.InternalServerError;

      // TODO normal filters
      if (exception is ApplicationException)
      {
        statusCode = HttpStatusCode.BadRequest;
        message = exception.Message;
      }
      else
      {
        Logger.Error("Unknown exception", exception);
        message = "Oops. Something went wrong.";
      }

      var result = JsonConvert.SerializeObject(new {message});
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)statusCode;
      await context.Response.WriteAsync(result);
    }
  }
}
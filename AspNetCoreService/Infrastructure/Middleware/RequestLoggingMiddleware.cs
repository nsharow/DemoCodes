using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace DemoCodes.AspNetCoreService.Infrastructure.Middleware
{
  /// <summary>
  /// Компонент middleware для логирования 
  /// </summary>
  public class RequestLoggingMiddleware
  {
    // Писать в лог предупреждение,
    // если время выполнения запроса в миллисекундах
    // превышает указанное    
    const int kWarnPeriod = 1000;

    private readonly RequestDelegate next;
    private readonly ILogger<RequestLoggingMiddleware> logger;

    public RequestLoggingMiddleware(RequestDelegate next,
        ILogger<RequestLoggingMiddleware> logger)
    {
      this.next = next;
      this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
      object ip = null;
      context.Items.TryGetValue("ClientIP", out ip);
      string queryString = $"{context.Request.Method} {context.Request.PathBase}/{context.Request.Path}?{context.Request.QueryString}";

      logger.LogInformation("{QueryId}. Начало выполнения запроса {QueryString}. IP клиента: {ClientIP}",
        context.TraceIdentifier,
        queryString,
        ip);

      Exception e = null;
      Stopwatch sw = Stopwatch.StartNew();
      try
      {
        await next?.Invoke(context);
      }
      catch (AggregateException ex)
      {
        e = ex.InnerException;
      }
      catch (Exception ex)
      {
        e = ex;
      }
      sw.Stop();

      if (e != null)
      {
        logger.LogError(e, "{QueryId}. Ошибка выполнения запроса {QueryString}. IP клиента: {ClientIP}. {ErrorMsg}",
            context.TraceIdentifier,
            queryString,
            ip, 
            e.Message);
        context.Response.StatusCode = 500;
        await context.Response.WriteAsync("Ошибка выполнения запроса");
      }
      else
      {
        var level = sw.ElapsedMilliseconds >= kWarnPeriod 
          ? LogLevel.Warning
          : LogLevel.Information;
        logger.Log(level, "{QueryId}. Окончание выполнения запроса {QueryString}. IP клиента: {ClientIP}. Период: {Period}",
            context.TraceIdentifier,
            queryString,
            ip, 
            sw.ElapsedMilliseconds);
      }
    }
  }

  public static class RequestLoggingMiddlewareExtentions
  {
    public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder,
        ILoggerFactory logFactory)
    {
      ILogger<RequestLoggingMiddleware> logger = logFactory?.CreateLogger<RequestLoggingMiddleware>();
      return builder.UseMiddleware<RequestLoggingMiddleware>(logger);
    }
  }
}

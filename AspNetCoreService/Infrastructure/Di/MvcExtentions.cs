using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace DemoCodes.AspNetCoreService.Infrastructure.Di
{
  static class MvcExtentions
  {
    public static void ConfigureValidationProblemDetails(this IServiceCollection services)
    {
      var ser = services ?? throw new ArgumentNullException(nameof(services));
      ser.Configure<ApiBehaviorOptions>(options =>
      {
        options.InvalidModelStateResponseFactory = context =>
        {
          var problemDetails = new ValidationProblemDetails(context.ModelState)
          {
            Instance = context.HttpContext.Request.Path,
            Status = StatusCodes.Status400BadRequest,
            Type = $"https://httpstatuses.com/400",
            Detail = "Неверные параметры запроса"
          };
          return new BadRequestObjectResult(problemDetails)
          {
            ContentTypes = { "application/problem+json", "application/problem+xml" }
          };
        };
      });
    }

    public static void AddSwagger(this IServiceCollection services)
    {
      var ser = services ?? throw new ArgumentNullException(nameof(services));
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc(ApiConstants.ApiVersion, new OpenApiInfo
        {
          Title = "ArchiveService API",
          Version = ApiConstants.ApiVersion,
          Description = "API взаимодействия с хранилищем документов декларанта, размещенных в архиве ТО"
        });
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
      });
    }
  }
}

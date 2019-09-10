using System;
using DemoCodes.AspNetCoreService.Infrastructure.Queries;
using DemoCodes.AspNetCoreService.Models;
using DemoCodes.AspNetCoreService.Queries;
using DemoCodes.AspNetCoreService.Queries.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace DemoCodes.AspNetCoreService.Infrastructure.Di
{
  static class QueryLayerExtentions
  {
    /// <summary>
    /// Расширения для кофигурирования диспетчера пользовательских запросов
    /// </summary>
    /// <param name="services"></param>
    public static void AddQueries(this IServiceCollection services)
    {
      var ser = services ?? throw new ArgumentNullException(nameof(services));
      ser.AddScoped<IQueryHandler<ArchiveDocPageQuery, ArchiveDocumentPage>, ArchiveDocPageQueryHandler>();
      ser.AddScoped<IQueryDispatcher, QueryDispatcher>();
    }
  }
}

using DemoCodes.AspNetCoreService.Queries.Handlers;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DemoCodes.AspNetCoreService.Infrastructure.Queries
{
  public class QueryDispatcher : IQueryDispatcher
  {
    private IServiceProvider queryResolver;

    public QueryDispatcher(IServiceProvider queryResolver)
    {
      this.queryResolver = queryResolver ?? throw new ArgumentNullException(nameof(queryResolver));
    }

    public async Task<TResult> ExecuteAsync<TQuery, TResult>(TQuery query) where TQuery : class
    {
      if (query == null) throw new ArgumentNullException(nameof(query));
      var handler = queryResolver.GetService<IQueryHandler<TQuery, TResult>>();
      if (handler == null) throw new InvalidOperationException(
        $"Обработчик для запросов типа {nameof(TQuery)} с возращаемым результатом {nameof(TResult)} не найден");
      return await handler.HandleAsync(query);
    }
  }
}

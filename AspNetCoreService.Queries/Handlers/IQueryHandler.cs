using System.Threading.Tasks;

namespace DemoCodes.AspNetCoreService.Queries.Handlers
{
  /// <summary>
  /// Базовый интерфейс обработчика пользовательских запросов
  /// </summary>
  /// <typeparam name="TQuery">Тип запроса</typeparam>
  /// <typeparam name="TResult">Тип возвращаемого результата</typeparam>
  public interface IQueryHandler<TQuery, TResult>
    where TQuery : class
  {
    Task<TResult> HandleAsync(TQuery query);
  }
}

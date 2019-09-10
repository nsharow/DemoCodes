using System.Threading.Tasks;

namespace DemoCodes.AspNetCoreService.Infrastructure.Queries
{
  /// <summary>
  /// Базовый интерфейс диспетчера пользовательских запросов
  /// </summary>
  public interface IQueryDispatcher
  {
    Task<TResult> ExecuteAsync<TQuery, TResult>(TQuery query) where TQuery : class;
  }
}

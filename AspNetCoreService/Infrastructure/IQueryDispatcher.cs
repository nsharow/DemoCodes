using System.Threading.Tasks;

namespace DemoCodes.AspNetCoreService.Infrastructure
{
  public interface IQueryDispatcher
  {
    Task<TResult> ExecuteAsync<TQuery, TResult>(TQuery query) where TQuery : class;
  }
}

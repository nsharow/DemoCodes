using System.Threading.Tasks;

namespace DemoCodes.AspNetCoreService.Queries.Handlers
{
  public interface IQueryHandler<TQuery, TResult>
    where TQuery : class
  {
    Task<TResult> HandleAsync(TQuery query);
  }
}

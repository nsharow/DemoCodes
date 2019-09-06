namespace DemoCodes.AspNetCoreService.Data.QueryObjects
{
  /// <summary>
  /// Фабрика для создания объект-запросов 
  /// </summary>
  public interface IQueryObjectFactory
  {
    T Create<T>() where T : IQueryObject;
  }
}

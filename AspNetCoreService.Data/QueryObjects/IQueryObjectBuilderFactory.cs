namespace DemoCodes.AspNetCoreService.Data.QueryObjects
{
  /// <summary>
  /// Фабрика для создания объект-запросов 
  /// </summary>
  public interface IQueryObjectBuilderFactory
  {
    T Create<T>() where T : IQueryObjectBuilder;
  }
}

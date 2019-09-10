namespace DemoCodes.AspNetCoreService.Data.QueryObjects
{
  /// <summary>
  /// Базовый интерфейс для всех строителей объект-запросов
  /// </summary>
  public interface IQueryObjectBuilder
  {
    QueryObject Build();
  }
}

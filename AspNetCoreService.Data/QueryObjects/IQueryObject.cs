namespace DemoCodes.AspNetCoreService.Data.QueryObjects
{
  /// <summary>
  ///   Объект-запрос, содержит строку SQL-запроса и список параметров,
  ///   ипользуется для работы с Dapper
  /// </summary>
  public interface IQueryObject
  {
    /// <summary>
    ///   Строка SQL-запроса
    /// </summary>
    string Sql { get; }
    
    /// <summary>
    ///   Список параметров запроса
    /// </summary>
    object QueryParams { get; }
  }
}

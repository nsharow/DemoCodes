namespace DemoCodes.AspNetCoreService.Data.QueryObjects
{
  /// <summary>
  ///   Объект-запрос, содержит строку SQL-запроса и список параметров,
  ///   ипользуется для работы с Dapper
  /// </summary>
  public class QueryObject
  {
    /// <summary>
    ///   Строка SQL-запроса
    /// </summary>
    public string Sql { get; }
    
    /// <summary>
    ///   Список параметров запроса
    /// </summary>
    public object QueryParams { get; }

    public QueryObject(string sqlString, object parameters)
    {
      Sql = sqlString;
      QueryParams = parameters;
    }
  }
}

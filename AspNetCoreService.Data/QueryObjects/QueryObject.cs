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
    ///  Объект с параметрами для передачи в Dapper
    /// </summary>
    public object QueryParams { get; }

    /// <summary>
    ///   Конструктор
    /// </summary>
    /// <param name="sqlString">Строка с SQL-запросом</param>
    /// <param name="parameters">Объект с параметрами для передачи в Dapper</param>
    public QueryObject(string sqlString, object parameters)
    {
      Sql = sqlString;
      QueryParams = parameters;
    }
  }
}

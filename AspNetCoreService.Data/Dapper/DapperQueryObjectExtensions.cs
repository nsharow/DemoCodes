using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using DemoCodes.AspNetCoreService.Data.QueryObjects;

namespace DemoCodes.AspNetCoreService.Data.Dapper
{
  /// <summary>
  ///   Расширения Dapper для работы с QueryObject  
  /// </summary>
  public static class DapperQueryObjectExtensions
  {
    public static IEnumerable<T> Query<T>(this IDbConnection cnn, QueryObject queryObject, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
    {
      return cnn.Query<T>(queryObject.Sql, queryObject.QueryParams, transaction, buffered, commandTimeout, commandType);
    }

    public static int Execute(this IDbConnection cnn, QueryObject queryObject, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
    {
        return cnn.Execute(queryObject.Sql, queryObject.QueryParams, transaction, commandTimeout, commandType);
    }

    public async static Task<IEnumerable<T>> QueryAsync<T>(this IDbConnection cnn, QueryObject queryObject, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
    {
        return await cnn.QueryAsync<T>(queryObject.Sql, queryObject.QueryParams, transaction, commandTimeout, commandType);
    }
  }
}

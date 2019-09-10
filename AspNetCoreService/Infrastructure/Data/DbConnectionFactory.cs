using DemoCodes.AspNetCoreService.Configuration;
using DemoCodes.AspNetCoreService.Data.Infrastructure;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace DemoCodes.AspNetCoreService.Infrastructure.Data
{
  static class DbProviders
  {
    public const string Oracle = "oracle";
  }

  /// <summary>
  /// Реализация фабрики соединений к БД,
  /// получает из конфигурации список <see cref="DbConnectionConfig" />,
  /// по которым настраивает провайдеры подключений
  /// </summary>
  class DbConnectionFactory : IConnectionFactory
  {
    private IDictionary<string, DbConnectionConfig> configurationList;

    public DbConnectionFactory(IDictionary<string, DbConnectionConfig> configurationList)
    {
      this.configurationList = configurationList
        ?? throw new ArgumentNullException(nameof(configurationList));
    }

    #region IConnectionFactory implrmrntation
    public IDbConnection Create(string name)
    {
      DbConnectionConfig dbConnectionConfig = null;
      if (configurationList?.TryGetValue(name, out dbConnectionConfig) ?? false)
      {
        switch ((dbConnectionConfig.Provider?.ToLower() ?? ""))
        {
          case var prv when prv == DbProviders.Oracle:
            return CreateOraConnection(dbConnectionConfig);
          default:
            throw new InvalidOperationException($"Тип провайдера данных {dbConnectionConfig.Provider} не поддерживается");
        }
      }
      throw new InvalidOperationException($"Конфигурация для соединения {name} не найдена");
    }

    private IDbConnection CreateOraConnection(DbConnectionConfig connectionConfig)
    {
      var builder = new OracleConnectionStringBuilder();
      builder.ConnectionString = connectionConfig.ConnectionString ?? "";
      if (!string.IsNullOrWhiteSpace(connectionConfig.UserName))
      {
        builder.UserID = connectionConfig.UserName;
      }
      if (!string.IsNullOrEmpty(connectionConfig.Password))
      {
        builder.Password = connectionConfig.Password;
      }
      return new OracleConnection(builder.ConnectionString);
    }
    #endregion
  }
}

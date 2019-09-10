using DemoCodes.AspNetCoreService.Configuration;
using DemoCodes.AspNetCoreService.Data.QueryObjects;
using DemoCodes.AspNetCoreService.Data.QueryObjects.Impl.Ora;
using DemoCodes.AspNetCoreService.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace DemoCodes.AspNetCoreService.Infrastructure.Di
{
  using QueriesConstants = DemoCodes.AspNetCoreService.Queries.Constants;

  /// <summary>
  /// Расширения для конфигурации слоя доступа к данным
  /// </summary>
  static class DataLayerExtentions
  {
    public static void ConfigureDataLayer(this IServiceCollection services, IConfiguration configuration)
    {
      var ser = services ?? throw new ArgumentNullException(nameof(services));
      var dbConnectionList = configuration.GetSection(ConfigurationConstants.DbConnectionsSection)
        .Get<Dictionary<string,DbConnectionConfig>>();      
      ConfigureArchiveDataLayer(ser, dbConnectionList);
    }

    private static void ConfigureArchiveDataLayer(IServiceCollection services,
      IDictionary<string, DbConnectionConfig> dbConnectionList)
    {
      DbConnectionConfig dbConnectionConfig = null;
      if (dbConnectionList?.TryGetValue(QueriesConstants.ArchiveDbName, out dbConnectionConfig) ?? false)
      {
        switch ((dbConnectionConfig.Provider?.ToLower() ?? ""))
        {
          case var prv when prv == DbProviders.Oracle:
            {
              ConfigureOraArchiveDataLayer(services, dbConnectionConfig);
              break;
            }            
          default:
            throw new InvalidOperationException($"Тип провайдера данных {dbConnectionConfig.Provider} не поддерживается");
        }
      }
      throw new InvalidOperationException($"Конфигурация для соединения {QueriesConstants.ArchiveDbName} не найдена");
    }

    private static void ConfigureOraArchiveDataLayer(IServiceCollection services, DbConnectionConfig dbConnectionConfig)
    {
      IQueryObjectBuilderFactory oraBuilderFactory = new QueryObjectBuilderFactoryOra(dbConnectionConfig.SchemaOwner ?? "");
      services.AddSingleton(oraBuilderFactory);
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCodes.AspNetCoreService.Configuration
{
  static class ConfigurationConstants
  {
    /// <summary>
    /// Наименования секции в конфигурации,
    /// содержащей список подключений
    /// </summary>
    public const string DbConnectionsSection = "DbConnections";
    /// <summary>
    /// Имя конфигурации подключения к архивной БД
    /// </summary>
    public const string ArchiveDbConnectionName = "ArchiveDb";
  }
}

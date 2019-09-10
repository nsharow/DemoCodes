using System.Data;

namespace DemoCodes.AspNetCoreService.Data.Infrastructure
{
  /// <summary>
  ///   Фабрика для получения <see cref="IDbConnection" />
  /// </summary>
  public interface IConnectionFactory
  {
    /// <summary>
    ///   Создает <see cref="IDbConnection" /> />
    /// </summary>
    /// <param name="name">Имя строки подключения</param>
    IDbConnection Create(string name);
  }
}

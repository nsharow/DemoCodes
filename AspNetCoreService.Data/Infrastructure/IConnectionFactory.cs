namespace DemoCodes.AspNetCoreService.Data.Infrastructure
{
  /// <summary>
  ///   Фабрика для получения <see cref="ConnectionDescriptor" />
  /// </summary>
  public interface IConnectionFactory
  {
    /// <summary>
    ///   Создает <see cref="ConnectionDescriptor" /> для строки подключения с именем <paramref name="name" />
    /// </summary>
    /// <param name="name">Имя строки подключения</param>
    ConnectionDescriptor Create(string name);
  }
}

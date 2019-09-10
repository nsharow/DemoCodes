namespace DemoCodes.AspNetCoreService.Configuration
{
  /// <summary>
  /// Конфигурация с параметрами работы с БД 
  /// </summary>
  public class DbConnectionConfig
  {
    /// <summary>
    /// Тип провайдера Ado.Net 
    /// </summary>
    public string Provider { get; set; }
    /// <summary>
    /// Строка подключения к БД
    /// </summary>
    public string ConnectionString { get; set; }
    /// <summary>
    /// Имя владельца схемы
    /// </summary>
    public string SchemaOwner { get; set; }
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string UserName { get; set; }
    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }
  }
}

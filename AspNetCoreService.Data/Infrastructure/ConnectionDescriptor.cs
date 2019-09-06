using System;
using System.Data;

namespace DemoCodes.AspNetCoreService.Data.Infrastructure
{
  /// <summary>
  /// Содежит IDbConnection и имя владельца схемы БД
  /// </summary>
  public class ConnectionDescriptor : IDisposable
  {
    public IDbConnection Connection { get; set; }
    public string SchemeOwner { get; set; }
    
    public ConnectionDescriptor(IDbConnection connection, string schemeOwner = "")
    {
      Connection = connection;
      SchemeOwner = schemeOwner;
    }

    #region IDisposable Support

    private bool disposed = false;

    public void Dispose()
    {
      if (!disposed)
      {
        Connection?.Dispose();
        disposed = true;
      }
    }
    
    #endregion
  }
}

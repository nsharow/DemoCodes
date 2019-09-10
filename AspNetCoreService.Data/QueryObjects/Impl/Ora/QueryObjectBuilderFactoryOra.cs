using System;

namespace DemoCodes.AspNetCoreService.Data.QueryObjects.Impl.Ora
{
  /// <summary>
  /// Фабрика строителей объект-запросов для СУБД Oracle 
  /// </summary>
  public class QueryObjectBuilderFactoryOra : IQueryObjectBuilderFactory
  {
    private readonly string schemeOwner;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="schemeOwner">Имя владельца схемы</param>
    public QueryObjectBuilderFactoryOra(string schemeOwner = "")
    {
      this.schemeOwner = schemeOwner;
    }

    #region IQueryObjectBuilderFactory implementation
    public T Create<T>() where T : IQueryObjectBuilder
    {
      switch (typeof(T))
      {
        case var qot when qot == typeof(ISelectDocListPage):
        {
          ISelectDocListPage selectDocListPageOra = new SelectDocListPageOra(schemeOwner);
          return (T)selectDocListPageOra;
        }
        default:
          throw new InvalidOperationException($"Тип построителя запроса {nameof(T)} не поддерживается");          
      }
    }
    #endregion
  }
}

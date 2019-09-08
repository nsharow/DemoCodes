using System;

namespace DemoCodes.AspNetCoreService.Data.QueryObjects.Impl.Ora
{
  public class QueryObjectBuilderFactoryOra : IQueryObjectBuilderFactory
  {
    private readonly string schemeOwner;

    public QueryObjectBuilderFactoryOra(string schemeOwner = "")
    {
      this.schemeOwner = schemeOwner;
    }

    public T Create<T>() where T : IQueryObjectBuilder
    {
      switch (typeof(T))
      {
        case var qot when qot == typeof(ISelectDocListPage):
        {
          ISelectDocListPage selectDocListPageOra = new SelectDocListPageLite(schemeOwner);
          return (T)selectDocListPageOra;
        }
        default:
          throw new InvalidOperationException($"Тип построителя запроса {nameof(T)} не поддерживается");          
      }
    }
  }
}

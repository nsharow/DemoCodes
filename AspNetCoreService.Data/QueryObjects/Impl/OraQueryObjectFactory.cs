using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCodes.AspNetCoreService.Data.QueryObjects.Impl
{
  public class OraQueryObjectFactory : IQueryObjectFactory
  {
    private readonly string schemeOwner;

    public OraQueryObjectFactory(string schemeOwner = "")
    {
      this.schemeOwner = schemeOwner;
    }

    public T Create<T>() where T : IQueryObject
    {
      switch (typeof(T))
      {
        case var qot when qot == typeof(ISelectDocListPage):
          {
            SelectDocListPageOra selectDocListPageOra = new SelectDocListPageOra(schemeOwner);
            return selectDocListPageOra;
          }         
      }
    }
  }
}

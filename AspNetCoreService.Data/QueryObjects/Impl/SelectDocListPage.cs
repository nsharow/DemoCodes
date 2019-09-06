using System;

namespace DemoCodes.AspNetCoreService.Data.QueryObjects.Impl
{
  abstract class SelectDocListPage : ISelectDocListPage
  {
    private string declarantId = "";
    private int customsType = 1;
    private DateTime creationDate = DateTime.MinValue.Date;
    private DateTime endDate = DateTime.MinValue.Date;
    private DateTime lastUsageDate = DateTime.MinValue.Date;
    private long pageSize = 0;
    private long pageNumber = 0;

    public string Sql => CreateSqlTemplate();
    public object QueryParams => CreateQueryParams();

    public IQueryObject AtCustomsWhithType(ushort customsType)
    {
      this.customsType = customsType;
      return this;
    }

    public IQueryObject CreatedAfter(DateTime creationDate)
    {
      this.creationDate = creationDate;
      return this;
    }

    public IQueryObject EndDateNotEarlier(DateTime endDate)
    {
      this.endDate = endDate;
      return this;
    }

    public IQueryObject ForDeclarant(string declarantId)
    {
      this.declarantId = declarantId;
      return this;
    }

    public IQueryObject GetPage(uint pageNumber, uint pageSize)
    {
      this.pageNumber = pageNumber;
      this.pageSize = pageSize;
      return this;
    }

    public IQueryObject LastUsageNotEarlier(DateTime lastUsageDate)
    {
      this.lastUsageDate = lastUsageDate;
      return this;
    }

    protected abstract string CreateSqlTemplate();

    private object CreateQueryParams()
    {
      return new
      {
        declarantId,
        customsType,
        lastUsageDate,
        creationDate,
        endDate,
        min = pageNumber * pageSize,
        max = pageSize * (pageNumber + 1) + 1
      };
    }
  }
}

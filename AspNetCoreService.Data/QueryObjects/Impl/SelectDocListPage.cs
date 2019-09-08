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

    public ISelectDocListPage AtCustomsWhithType(ushort customsType)
    {
      this.customsType = customsType;
      return this;
    }

    public QueryObject Build()
    {
      return new QueryObject(
        CreateSqlTemplate(),
        CreateQueryParams());
    }

    public ISelectDocListPage CreatedAfter(DateTime creationDate)
    {
      this.creationDate = creationDate;
      return this;
    }

    public ISelectDocListPage EndDateNotEarlier(DateTime endDate)
    {
      this.endDate = endDate;
      return this;
    }

    public ISelectDocListPage ForDeclarant(string declarantId)
    {
      this.declarantId = declarantId;
      return this;
    }

    public ISelectDocListPage GetPage(uint pageNumber, uint pageSize)
    {
      this.pageNumber = pageNumber;
      this.pageSize = pageSize;
      return this;
    }

    public ISelectDocListPage LastUsageNotEarlier(DateTime lastUsageDate)
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

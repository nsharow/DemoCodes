using System;

namespace DemoCodes.AspNetCoreService.Data.QueryObjects.Impl
{
  abstract class SelectDocListPage : ISelectDocListPage
  {
    private string declarantId = "";
    private int customsType = 1;
    private DateTime fromCreationDate = DateTime.MinValue.Date;
    private DateTime minEndDate = DateTime.MinValue.Date;
    private DateTime lastUsageDate = DateTime.MinValue.Date;
    private bool newerDocsFirst = true;
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
        CreateSqlTemplate(newerDocsFirst),
        CreateQueryParams());
    }

    public ISelectDocListPage CreatedAfter(DateTime creationDate)
    {
      this.fromCreationDate = creationDate;
      return this;
    }

    public ISelectDocListPage EndDateNotEarlier(DateTime endDate)
    {
      this.minEndDate = endDate;
      return this;
    }

    public ISelectDocListPage ForDeclarant(string declarantId)
    {
      this.declarantId = declarantId;
      return this;
    }

    public ISelectDocListPage NewerDocsFirst(bool newerDocsFirst)
    {
      this.newerDocsFirst = newerDocsFirst;
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

    protected abstract string CreateSqlTemplate(bool newerDocsFirst);

    private object CreateQueryParams()
    {
      return new
      {
        declarantId,
        customsType,
        lastUsageDate,
        fromCreationDate,
        minEndDate,
        minRow = (pageNumber - 1) * pageSize + 1,
        maxRow = pageNumber * pageSize
      };
    }
  }
}

using System;

namespace DemoCodes.AspNetCoreService.Data.QueryObjects.Impl
{
  /// <summary>
  /// Базовый клас для всех строителей объект-запроса
  /// получения страницы с документами в архиве декларанта
  /// </summary>
  abstract class SelectDocListPage : ISelectDocListPage
  {
    private string declarantId = "";
    private int customsType = 1;
    private DateTime fromCreationDate = DateTime.MinValue.Date;
    private DateTime minEndDate = DateTime.MinValue.Date;
    private DateTime lastUsageDate = DateTime.MinValue.Date;
    private bool newerDocsFirst = true;
    private long pageSize = 0;
    private long pageNumber = 1;

    #region ISelectDocListPage implementation
    public ISelectDocListPage AtCustomsWhithType(ushort customsType)
    {
      this.customsType = customsType;
      return this;
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
    #endregion

    #region IQueryObjectBuilder implementation
    public QueryObject Build()
    {
      return new QueryObject(
        CreateSqlTemplate(newerDocsFirst),
        CreateQueryParams());
    }

    /// <summary>
    /// Получение строки SQL-запроса для конкретной реализации строителя
    /// </summary>
    /// <param name="newerDocsFirst">Сортировать документы по времени создания</param>
    /// <returns>Строка SQL-запроса</returns>
    protected abstract string CreateSqlTemplate(bool newerDocsFirst);

    /// <summary>
    /// Создание объекта с параметрами для использования в Dapper
    /// </summary>
    /// <returns>Объект с параметрами запроса</returns>
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
    #endregion
  }
}

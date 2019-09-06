using System;

namespace DemoCodes.AspNetCoreService.Data.QueryObjects
{
  /// <summary>
  ///   Запрос страничного получения списка документов для декларанта
  /// </summary>
  public interface ISelectDocListPage : IQueryObject
  {
    /// <summary>
    ///   Задает код участника ВЭД - владельца документов
    /// </summary>
    IQueryObject ForDeclarant(string declarantId);
    /// <summary>
    ///   Задает тип ТС, в которой созданы документы 
    /// </summary>
    IQueryObject AtCustomsWhithType(ushort customsType);
    /// <summary>
    ///   Задает нижнюю границу даты создания документа
    /// </summary>
    IQueryObject CreatedAfter(DateTime creationDate);
    /// <summary>
    ///   Задает нижнюю границу даты окончания действия документа
    /// </summary>
    IQueryObject EndDateNotEarlier(DateTime endDate);
    /// <summary>
    ///   Задает нижнюю границу даты последнего использования документа
    /// </summary>
    IQueryObject LastUsageNotEarlier(DateTime lastUsageDate);
    /// <summary>
    ///   Указывает номер требуемой страницы
    /// </summary>
    /// <param name="pageNumber">Номер страницы, начиная от 0</param>
    /// <param name="pageSize">Размер одной страницы</param>
    IQueryObject GetPage(uint pageNumber, uint pageSize);
  }
}

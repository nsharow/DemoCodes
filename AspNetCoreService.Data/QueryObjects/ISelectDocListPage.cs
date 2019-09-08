using System;

namespace DemoCodes.AspNetCoreService.Data.QueryObjects
{
  /// <summary>
  ///   Запрос страничного получения списка документов для декларанта
  /// </summary>
  public interface ISelectDocListPage : IQueryObjectBuilder
  {
    /// <summary>
    ///   Задает код участника ВЭД - владельца документов
    /// </summary>
    ISelectDocListPage ForDeclarant(string declarantId);
    /// <summary>
    ///   Задает тип ТС, в которой созданы документы 
    /// </summary>
    ISelectDocListPage AtCustomsWhithType(ushort customsType);
    /// <summary>
    ///   Задает нижнюю границу даты создания документа
    /// </summary>
    ISelectDocListPage CreatedAfter(DateTime creationDate);
    /// <summary>
    ///   Задает нижнюю границу даты окончания действия документа
    /// </summary>
    ISelectDocListPage EndDateNotEarlier(DateTime endDate);
    /// <summary>
    ///   Задает нижнюю границу даты последнего использования документа
    /// </summary>
    ISelectDocListPage LastUsageNotEarlier(DateTime lastUsageDate);
    /// <summary>
    ///   Указывает номер требуемой страницы
    /// </summary>
    /// <param name="pageNumber">Номер страницы, начиная от 0</param>
    /// <param name="pageSize">Размер одной страницы</param>
    ISelectDocListPage GetPage(uint pageNumber, uint pageSize);
  }
}

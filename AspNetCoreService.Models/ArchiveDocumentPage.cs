using System.Collections.Generic;

namespace DemoCodes.AspNetCoreService.Models
{
  /// <summary>
  /// Модель страницы с документами архива декларанта,
  /// возвращаемая клиенту
  /// </summary>
  public class ArchiveDocumentPage
  {
    /// <summary>
    /// Информация о странице
    /// </summary>
    public PageInfo PageInfo { get; }
    /// <summary>
    /// Список документов
    /// </summary>
    public IEnumerable<ArchiveDocument> Documents { get; }

    public ArchiveDocumentPage(PageInfo pageInfo,
      IEnumerable<ArchiveDocument> documents)
    {
      PageInfo = pageInfo;
      Documents = documents;
    }
  }
}

using System.Collections.Generic;

namespace DemoCodes.AspNetCoreService.Models
{
  public class ArchiveDocumentPage
  {
    public PageInfo PageInfo { get; }
    public IEnumerable<ArchiveDocument> Documents { get; }

    public ArchiveDocumentPage(PageInfo pageInfo,
      IEnumerable<ArchiveDocument> documents)
    {
      PageInfo = pageInfo;
      Documents = documents;
    }
  }
}

namespace DemoCodes.AspNetCoreService.Data.QueryObjects.Impl.Lite
{
  class SelectDocListPageLite : SelectDocListPage
  {
    static readonly string sqlTemplate =
      "SELECT * FROM ( SELECT ADR.* FROM (SELECT A.DeclarantId, A.CustomsType, A.ArchiveName,"
      + " AD.* FROM {0}ArchiveDocuments AD"
      + " JOIN {0}Archives A ON A.ArchiveId = AD.ArchiveId) ADR"
      + " WHERE ADR.DeclarantId = :declarantId AND ADR.CustomsType = :customsType"
      + " AND ADR.CreationTime >= :creationDate AND (EndDate IS NULL OR EndDate >= :endDate)"
      + " AND ADR.LastUsageTime >= :lastUsageDate "
      + " ORDER BY ADR.Id DESC) ADN WHERE rownum < :max ) WHERE R__ >= :min ORDER BY R__ ASC";

    protected override string CreateSqlTemplate()
    {
      return sqlTemplate;
    }
  }
}

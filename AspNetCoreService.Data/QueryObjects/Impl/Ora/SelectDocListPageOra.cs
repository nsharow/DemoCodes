namespace DemoCodes.AspNetCoreService.Data.QueryObjects.Impl.Ora
{
  /// <summary>
  /// Реализация строителя объект-запроса
  /// получения страницы с документами в архиве декларанта
  /// для СУБД Oracle
  /// </summary>
  class SelectDocListPageOra : SelectDocListPage
  {
    static readonly string sqlTemplate =
      "select *"
      + " FROM ("
      +   " SELECT"
      +     " ROW_NUMBER() over (ORDER BY AD.ID {0}) RowNumber,"
      +     " AD.ID Id, AD.ARCH_DOC_ID ArchiveDocId, AD.ARCH_DOC_CODE DocCode, AD.ARCH_DOC_NAME DocName,"
      +     " AD.ARCH_DOC_NUMBER DocNumber, AD.ARCH_DOC_DATE DocDate,"
      +     " AD.ARCH_DOC_BEGIN_DATE DocBeginDate, AD.ARCH_DOC_END_DATE DocEndDate,"
      +     " AD.DOCTYPE DocType, AD.DOCUMENTMODEID DocModeId, AD.SOFTVERSION DocVersion, AD.DOC_HASH DocHash,"
      +     " AD.ORDERID DocState, AD.LAST_USAGE DocLastUsageTime, AD.DT_USED_REG_NUM FirstUsageDtNumber,"
      +     " AD.ARCH_DOC_STATUS DocArchiveStatus, AD.COMMENTS DocComments,"
      +     " A.ARCHIVE_ID ArchiveId, A.ARCHIVE_NAME ArchiveName"
      +   " FROM {1}ESAD_ARCHIVE_DOCS AD"
      +   " JOIN {1}ESAD_ARCHIVES A"
      +   " ON A.ARCHIVE_ID = AD.ARCH_ID"
      +   " WHERE A.DECLARANT_ID = :declarantId"
      +     " AND A.STATUS = :customsType"
      +     " AND AD.ARCH_DOC_CREATION_DATE >= :fromCreationDate"
      +     " AND (AD.ARCH_DOC_END_DATE IS NULL OR AD.ARCH_DOC_END_DATE >= :minEndDate)"
      +     " AND AD.LAST_USAGE >= :lastUsageDate)"
      + " WHERE RowNumber BETWEEN :minRow AND :maxRow  ORDER BY RowNumber";

    private readonly string schemeOwner;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="schemeOwner">Имя владельца схемы</param>
    public SelectDocListPageOra(string schemeOwner)
    {
      this.schemeOwner = schemeOwner;
    }

    protected override string CreateSqlTemplate(bool newDocFirst)
    {
      return string.Format(sqlTemplate,
        newDocFirst ? "DESC" : "ASC",
        string.IsNullOrWhiteSpace(schemeOwner) ? "" : (schemeOwner + "."));
    }
  }
}

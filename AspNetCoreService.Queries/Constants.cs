namespace DemoCodes.AspNetCoreService.Queries
{
  public static class Constants
  {
    /// <summary>
    /// Максимальный срок хранения документов в архиве в годах
    /// </summary>
    public const int MaxExpirationYears = 10;
    /// <summary>
    /// Погрешность в днях, добавляемая к DocEndDate
    /// после истечения срока действия документа.
    /// Соответствует примерному времени реакции таможенной
    /// системы на просроченные документы
    /// </summary>
    public const int MaxExpirationDays = 3;
    /// <summary>
    /// Максимальный срок неиспользуемых документов в годах
    /// </summary>
    public const int MaxLastUsageYears = 10;

    /// <summary>
    /// Наименование подключения к БД с архивами
    /// </summary>
    public const string ArchiveDbName = "ArchiveDb";
  }
}

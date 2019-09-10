using System;

namespace DemoCodes.AspNetCoreService.Models
{
  /// <summary>
  /// Модель документа в архиве декларанта
  /// </summary>
  public class ArchiveDocument
  {
    /// <summary>
    /// Идентификатор документа в архиве
    /// </summary>
    public string ArchiveDocId { get; set; }
    /// <summary>
    /// Код вида документа
    /// </summary>
    public string DocCode { get; set; }
    /// <summary>
    /// Наименование документа
    /// </summary>
    public string DocName { get; set; }
    /// <summary>
    /// Номер документа
    /// </summary>
    public string DocNumber { get; set; }
    /// <summary>
    /// Дата документа
    /// </summary>
    public DateTime? DocDate { get; set; }
    /// <summary>
    /// Дата начала действия документа
    /// </summary>
    public DateTime? DocBeginDate { get; set; }
    /// <summary>
    /// Дата окончания действия документа
    /// </summary>
    public DateTime? DocEndDate { get; set; }
    /// <summary>
    /// Тип документа согласно альбому форматов 
    /// </summary>
    public string DocType { get; set; }
    /// <summary>
    /// Код типа документа согласно альбому форматов
    /// </summary>
    public string DocModeId { get; set; }
    /// <summary>
    /// Версия документа согласно альбому форматов
    /// </summary>
    public string DocVersion { get; set; }
    /// <summary>
    /// Хэш содержимого документа
    /// </summary>
    public int DocHash { get; set; }
    /// <summary>
    /// Код текущего внутреннего состояния документа
    /// </summary>
    public int DocState { get; set; }
    /// <summary>
    /// Время последнего использования ссылки на документ
    /// </summary>
    public DateTime DocLastUsageTime { get; set; }
    /// <summary>
    /// Регистрационный номер ДТ, в которой документ был впервые использован
    /// </summary>
    public string FirstUsageDtNumber { get; set; }
    /// <summary>
    /// Статус документа в таможенном архиве
    /// </summary>
    public string DocArchiveStatus { get; set; }
    /// <summary>
    /// Дополнительная информация о документе
    /// </summary>
    public string DocComments { get; set; }
    /// <summary>
    /// Таможенный иденификатор архива
    /// </summary>
    public string ArchiveId { get; set; }
    /// <summary>
    /// Имя таможенного архива
    /// </summary>
    public string ArchiveName { get; set; }
  }
}

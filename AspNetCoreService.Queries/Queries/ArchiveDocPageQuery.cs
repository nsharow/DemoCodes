using System;
using DemoCodes.AspNetCoreService.Models;

namespace DemoCodes.AspNetCoreService.Queries
{
  /// <summary>
  /// Запрос пользователя на получение страницы
  /// с документами в архиве декларанта
  /// </summary>
  public class ArchiveDocPageQuery
  {
    /// <summary>
    /// Код уч. ВЭД владельца архива
    /// </summary>
    public string DeclarantId { get; }
    /// <summary>
    /// Тип таможенной системы, в которой размещен архив
    /// </summary>
    public CustomsType FromCustomsType { get; }
    /// <summary>
    /// Размер одной страницы
    /// </summary>
    public uint PageSize => 500;
    /// <summary>
    /// Номер требуемой страницы, начиная от 1 
    /// </summary>
    public uint PageNumber { get; }
    /// <summary>
    /// Минимальная дата создания документа
    /// </summary>
    public DateTime? FromCreationDate { get; set; }
    /// <summary>
    /// Получать просроченные документы
    /// </summary>
    public bool WhithExpired { get; set; }
    /// <summary>
    /// Максимальное количество дней, прошедших
    /// с момента последнего использования документа
    /// </summary>
    public uint? LastUsageDaysElapsed { get; set; }
    /// <summary>
    /// Получать вначале более новый документы
    /// </summary>
    public bool NewerFirst { get; set; }

    public ArchiveDocPageQuery(string declarantId,
      CustomsType customsType, uint pageNumber)
    {
      DeclarantId = declarantId;
      FromCustomsType = customsType;
      PageNumber = pageNumber;
      NewerFirst = true;
    }
  }
}

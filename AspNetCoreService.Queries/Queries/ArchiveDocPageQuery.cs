using System;
using DemoCodes.AspNetCoreService.Models;

namespace DemoCodes.AspNetCoreService.Queries
{
  public class ArchiveDocPageQuery
  {
    public string DeclarantId { get; }
    public CustomsType FromCustomsType { get; }
    public uint PageSize => 500;
    public uint PageNumber { get; }
    public DateTime? FromCreationDate { get; set; }
    public bool WhithExpired { get; set; }
    public uint? LastUsageDaysElapsed { get; set; }
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

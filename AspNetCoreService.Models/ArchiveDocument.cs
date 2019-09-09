using System;

namespace DemoCodes.AspNetCoreService.Models
{
  public class ArchiveDocument
  {
    public string ArchiveDocId { get; set; }
    public string DocCode { get; set; }
    public string DocName { get; set; }
    public string DocNumber { get; set; }
    public DateTime? DocDate { get; set; }
    public DateTime? DocBeginDate { get; set; }
    public DateTime? DocEndDate { get; set; }
    public string DocType { get; set; }
    public string DocModeId { get; set; }
    public string DocVersion { get; set; }
    public int DocHash { get; set; }
    public int DocState { get; set; }
    public DateTime DocLastUsageTime { get; set; }
    public string FirstUsageDtNumber { get; set; }
    public string DocArchiveStatus { get; set; }
    public string DocComments { get; set; }
    public string ArchiveId { get; set; }
    public string ArchiveName { get; set; }
  }
}

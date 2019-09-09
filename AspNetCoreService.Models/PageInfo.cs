namespace DemoCodes.AspNetCoreService.Models
{
  public struct PageInfo
  {
    public uint PageNumber { get; }
    public bool HasNext { get; }
    public bool HasPrevious => PageNumber > 1;

    public PageInfo(uint pageNumber, bool hasNext)
    {
      PageNumber = pageNumber;
      HasNext = hasNext;
    }
  }
}

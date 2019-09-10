namespace DemoCodes.AspNetCoreService.Models
{
  /// <summary>
  /// Информация о странице, передаваемой клиенту
  /// </summary>
  public struct PageInfo
  {
    /// <summary>
    /// Номер страницы, начиная от 1
    /// </summary>
    public uint PageNumber { get; }
    /// <summary>
    /// Имеется ли следующая страница
    /// </summary>
    public bool HasNext { get; }
    /// <summary>
    /// Имеется ли предыдущая страница
    /// </summary>
    public bool HasPrevious => PageNumber > 1;

    public PageInfo(uint pageNumber, bool hasNext)
    {
      PageNumber = pageNumber;
      HasNext = hasNext;
    }
  }
}

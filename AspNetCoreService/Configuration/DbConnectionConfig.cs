namespace DemoCodes.AspNetCoreService.Configuration
{
  public class DbConnectionConfig
  {
    public string Provider { get; set; }
    public string ConnectionString { get; set; }
    public string SchemaOwner { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
  }
}

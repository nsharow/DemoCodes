using Microsoft.AspNetCore.Builder;

namespace DemoCodes.AspNetCoreService.Infrastructure.Middleware
{
  static class MvcExtentions
  {
    public static void UseSwaggerDoc(this IApplicationBuilder app)
    {
      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint($"/{ApiConstants.ApiVersion}/{ApiConstants.SwaggerPath}/swagger.json", "ArchiveService API");
      });
    }
  }
}

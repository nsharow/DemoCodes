using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DemoCodes.AspNetCoreService.Infrastructure.Di;
using DemoCodes.AspNetCoreService.Infrastructure.Middleware;

namespace DemoCodes.AspNetCoreService
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddResponseCompression();
      services.AddOptions();
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
      services.ConfigureValidationProblemDetails();
      services.AddSwagger();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseMvc();
      app.UseSwaggerDoc();
    }
  }
}

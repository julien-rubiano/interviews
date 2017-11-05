using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.AspNetCore;
using SimpleInjector.Integration.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi
{
  public class Startup
  {
    private Container container = new Container();

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;

    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();

      IntegrateSimpleInjector(services);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      InitializeContainer(app);

      container.Verify();

      app.UseMvc();
    }

    private void IntegrateSimpleInjector(IServiceCollection services)
    {
      container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

      services.AddSingleton<IControllerActivator>(
          new SimpleInjectorControllerActivator(container));
      services.AddSingleton<IViewComponentActivator>(
          new SimpleInjectorViewComponentActivator(container));

      services.EnableSimpleInjectorCrossWiring(container);
      services.UseSimpleInjectorAspNetRequestScoping(container);
    }

    private void InitializeContainer(IApplicationBuilder app)
    {
      // Add application presentation components:
      container.RegisterMvcControllers(app);
      container.RegisterMvcViewComponents(app);

      // Add application services. For instance:
      container.Register<IEmailService, EmailService>(Lifestyle.Scoped);

      // Cross-wire ASP.NET services (if any). For instance:
      container.CrossWire<ILoggerFactory>(app);
    }
  }
}

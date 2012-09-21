using System;

namespace app.tasks.startup.steps
{
  public class RegisterRoutes : ITakePartInStartup
  {
    IProvideStartupServices startup_services;

    public RegisterRoutes(IProvideStartupServices startup_services)
    {
      this.startup_services = startup_services;
    }

    public void run()
    {
      throw new NotImplementedException();
    }
  }
}
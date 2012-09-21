using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using app.web.core;
using app.web.core.aspnet;
using app.web.core.aspnet.stubs;
using app.web.core.stubs;

namespace app.tasks.startup.steps
{
  public class RegisterWebComponents : ITakePartInStartup
  {
    IProvideStartupServices startup_facility;

    public RegisterWebComponents(IProvideStartupServices startup_facility)
    {
      this.startup_facility = startup_facility;
    }

    public void run()
    {
      startup_facility.register<IProcessRequests, FrontController>();
      startup_facility.register<IFindCommands, CommandRegistry>();
      startup_facility.register<IEnumerable<IProcessOneRequest>, StubSetOfCommands>();
      startup_facility.register<IDisplayReports, WebFormDisplayEngine>();
      startup_facility.register<GetTheCurrentlyExecutingRequest_Behaviour>(() => HttpContext.Current);
      startup_facility.register<CreateRawPage_Behaviour>(BuildManager.CreateInstanceFromVirtualPath);
      startup_facility.register<ICreateDisplayHandlers, ASPPageFactory>();
      startup_facility.register<IFindPathsToLogicalViews, StubPathRegistry>();
    }
  }
}
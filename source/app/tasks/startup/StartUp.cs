using app.utility.container;
using app.web.core;

namespace app.tasks.startup
{
  public class StartUp
  {
    public static void run()
    {
      GetTheActiveContainer_Behaviour resolution = () => new Container(null, null);
      Dependencies.container_resolver = resolution;
      new DependencyCreator(x => x == typeof(IProcessRequests), new FunctionalItemFactory(() => new FrontController()));

    }
  }
}
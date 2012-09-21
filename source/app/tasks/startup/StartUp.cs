using app.tasks.startup.steps;

namespace app.tasks.startup
{
  public class StartUp
  {
    public static void run()
    {
      Start.by<RegisterCoreComponents>()
        .followed_by<RegisterWebComponents>()
        .finish_by<RegisterRoutes>();
    }
  }
}
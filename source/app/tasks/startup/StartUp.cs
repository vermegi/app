using app.utility.container;

namespace app.tasks.startup
{
  public class StartUp
  {
    public static void run()
    {
      GetTheActiveContainer_Behaviour resolution = () => new Container(null, null);
      Dependencies.container_resolver = resolution;
    }
  }
}
namespace app.tasks.startup.steps
{
  public class RegisterCoreComponents : ITakePartInStartup
  {
    IProvideStartupServices startup_facility;

    public RegisterCoreComponents(IProvideStartupServices startup_facility)
    {
      this.startup_facility = startup_facility;
    }

    public void run()
    {
    }
  }
}
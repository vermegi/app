namespace app.tasks.startup
{
  public interface IProvideStartupServices
  {
    void register<Contract, Implementation>();
    void register<Contract>(Contract implementation);
  }
}
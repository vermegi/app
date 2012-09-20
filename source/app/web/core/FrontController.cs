namespace app.web.core
{
  public class FrontController : IProcessRequests
  {
    IFindCommands command_finder;

    public FrontController(IFindCommands command_finder)
    {
      this.command_finder = command_finder;
    }

    public void process(IEncapsulateRequestDetails request)
    {
      var the_command = command_finder.get_the_command_that_can_process(request);
      the_command.run(request);
    }
  }
}
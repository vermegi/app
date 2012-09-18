namespace app.web
{
  public interface IFindCommands
  {
    IProcessOneRequest get_the_command_that_can_process(IEncapsulateRequestDetails request);
  }
}
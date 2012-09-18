using System.Web.UI.WebControls;

namespace app.web
{
  public class FrontController : IProcessRequests
  {
      private IFindCommands command_finder;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:System.Object"/> class.
      /// </summary>
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
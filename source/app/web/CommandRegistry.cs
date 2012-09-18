using System.Collections.Generic;
using System.Linq;

namespace app.web
{
  public class CommandRegistry : IFindCommands
  {
      private IEnumerable<IProcessOneRequest> ProcessList;

      public CommandRegistry(IEnumerable<IProcessOneRequest> processList)
      {
          ProcessList = processList;
      }

      public IProcessOneRequest get_the_command_that_can_process(IEncapsulateRequestDetails request)
      {
          return ProcessList.Single(process => process.can_run(request));
    }
  }
}
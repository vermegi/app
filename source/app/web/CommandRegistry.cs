using System.Collections.Generic;
using System.Linq;

namespace app.web
{
  public class CommandRegistry : IFindCommands
  {
      private IEnumerable<IProcessOneRequest> all_commands;

      public CommandRegistry(IEnumerable<IProcessOneRequest> processList)
      {
          all_commands = processList;
      }

      public IProcessOneRequest get_the_command_that_can_process(IEncapsulateRequestDetails request)
      {
          return all_commands.Single(process => process.can_run(request));
    }
  }
}